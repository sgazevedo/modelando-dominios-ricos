using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Document : ValueObject
  {
    public Document(string number, DocumentType type) : base()
    {
      Number = number;
      Type = type;
    }

    public string Number { get; private set; }
    public DocumentType Type { get; private set; }
  }
}
