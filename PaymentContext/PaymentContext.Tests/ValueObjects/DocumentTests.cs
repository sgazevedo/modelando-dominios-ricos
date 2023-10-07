using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCnpjIsInvalid()
    {
      var document = new Document("1111111111111", DocumentType.CNPJ);
      Assert.IsTrue(document.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCnpjIsValid()
    {
      var document = new Document("66625749000132", DocumentType.CNPJ);
      Assert.IsTrue(document.Valid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("")]
    [DataRow("123456789")]
    [DataRow("123456789012")]
    public void ShouldReturnErrorWhenCpfIsInvalid(string number)
    {
      var document = new Document(number, DocumentType.CPF);
      Assert.IsTrue(document.Invalid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("34225545806")]
    [DataRow("54139739347")]
    [DataRow("01077284608")]
    public void ShouldReturnSuccessWhenCpfIsValid(string number)
    {
      var document = new Document(number, DocumentType.CPF);
      Assert.IsTrue(document.Valid);
    }
  }
}
