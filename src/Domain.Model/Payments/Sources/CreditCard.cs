namespace PaymentGateway.Domain.Model.Payments.Sources
{
    public class CreditCard : Source
    {
        public CreditCard(
            SourceType type,
            string number,
            int expiryMonth,
            int expiryYear,
            string name,
            string cvv,
            Billing billing) : base(type)
        {
            Number = number;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            Name = name;
            Cvv = cvv;
            Billing = billing;
        }

        public string Number { get; }

        public int ExpiryMonth { get; }

        public int ExpiryYear { get; }

        public string Name { get; }

        public string Cvv { get; }

        public Billing Billing { get; set; }
    }
}
