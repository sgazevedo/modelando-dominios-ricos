using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
  [TestClass]
  public class StudentQueriesTests
  {
    private IList<Student> _students;

    public StudentQueriesTests()
    {
      _students = new List<Student>();
      for (var i = 0; i <= 10; i++)
      {
        _students.Add(new Student(
            new Name("Aluno", i.ToString()),
            new Document("1111111111" + i.ToString(), DocumentType.CPF),
            new Email(i.ToString() + "@balta.io")
        ));
      }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      var expression = StudentQueries.GetStudentInfo("12345678911");
      var student = _students.AsQueryable().Where(expression).FirstOrDefault();

      Assert.IsNull(student);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
      var expression = StudentQueries.GetStudentInfo("11111111111");
      var student = _students.AsQueryable().Where(expression).FirstOrDefault();

      Assert.IsNotNull(student);
    }
  }
}
