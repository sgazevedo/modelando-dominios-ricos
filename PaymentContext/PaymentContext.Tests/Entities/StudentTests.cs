using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void StudentTest()
    {
      var student = new Student(firstName: "Fulano", lastName: "Silva", document: "123456789", email: "fulano@email.com");

    }
  }
}
