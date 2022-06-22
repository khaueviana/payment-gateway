namespace PaymentGateway.Application.Dto.Payments
{
    using PaymentGateway.Application.Dto.Payments.Sources;

    public class PaymentRequest
    {
        public string Reference { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }

        public Shipping Shipping { get; set; }

        public Source Source { get; set; }
    }
}
