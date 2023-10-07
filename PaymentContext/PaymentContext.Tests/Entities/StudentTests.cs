using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void StudentTest()
    {
      var name = new Name(firstName: "Fulano", lastName: "Silva");
      var document = new Document(number: "123456789", type: DocumentType.CPF);
      var email = new Email(address: "fulano@email.com");
      var student = new Student(name, document, email);

    }
  }
}
