namespace PaymentGateway.Presentation.Dto.Payment.Sources
{
    public class CreditCard : Source
    {
        public string Number { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public string Name { get; set; }

        public string Cvv { get; set; }

        public Billing Billing { get; set; }
    }
}
