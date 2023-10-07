using Flunt.Validations;
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

      AddNotifications(new Contract()
        .Requires()
        .IsTrue(Validate(), "Document.Number", "Documento inválido")
      );
    }

    public string Number { get; private set; }
    public DocumentType Type { get; private set; }

    private bool Validate()
    {
      if (Type == DocumentType.CNPJ && Number.Length == 14)
        return true;

      if (Type == DocumentType.CPF && Number.Length == 11)
        return true;

      return false;
    }
  }
}
