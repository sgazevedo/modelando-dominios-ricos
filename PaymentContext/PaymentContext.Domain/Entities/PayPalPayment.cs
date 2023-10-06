namespace PaymentContext.Domain.Entities
{
    internal class PayPalPayment : Payment
    {
        public string TransactionCode { get; private set; }
    }
}
