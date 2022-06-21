namespace PaymentGateway.Domain.Model.Sources
{
    public class CreditCard : Source
    {
        public string Number { get; }

        public int ExpiryMonth { get; }

        public int ExpiryYear { get; }

        public string Name { get; }

        public string Cvv { get; }

        public Billing Billing { get; }
    }
}
