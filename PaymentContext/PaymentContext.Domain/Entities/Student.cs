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
      InactiveAllSubscription();

      _subscriptions.Add(subscription);
    }

    public void InactiveAllSubscription()
    {
      foreach (var subscription in _subscriptions)
        subscription.Inactivate();
    }
  }
}