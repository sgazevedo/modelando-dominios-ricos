using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
  public class Student : Entity
  {
    private IList<Subscription> _subscriptions;

    public Student(Name name, Document document, Email email) : base()
    {
      Name = name;
      Document = document;
      Email = email;
      _subscriptions = new List<Subscription>();

      AddNotifications(name, document, email);
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions 
    { 
      get 
      {
        return _subscriptions.ToArray();
      }
    }

    public void AddSubscription(Subscription subscription) 
    {
      AddNotifications(new Contract()
          .Requires()
          .IsFalse(HasSubscriptionActive(), "Student.Subscriptions", "Você já tem uma assinatura ativa")
          .IsTrue(subscription.Payments.Any(), "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
      );

      if (Valid)
        _subscriptions.Add(subscription);
    }

    private bool HasSubscriptionActive() => _subscriptions.SingleOrDefault(x => x.Active)?.Active ?? false;
  }
}