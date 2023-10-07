using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Address _address;

    public StudentTests()
    {
      _name = new Name("Bruce", "Wayne");
      _document = new Document("35111507795", DocumentType.CPF);
      _email = new Email("batman@dc.com");
      _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
      _student = new Student(_name, _document, _email);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      var subscription = new Subscription(null);
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
      subscription.AddPayment(payment);
      _student.AddSubscription(subscription);
      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
      var subscription = new Subscription(null);
      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
      var firstSubscription = new Subscription(null);
      var firstPayment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
      firstSubscription.AddPayment(firstPayment);
      _student.AddSubscription(firstSubscription);
      firstSubscription.Inactivate();

      var secondSubscription = new Subscription(null);
      var secondPayment = new PayPalPayment("12345679", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
      secondSubscription.AddPayment(secondPayment);
      _student.AddSubscription(secondSubscription);

      Assert.IsTrue(_student.Valid);
    }
  }
}
