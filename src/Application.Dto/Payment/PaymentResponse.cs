namespace PaymentGateway.Application.Dto.Payment
{
    using PaymentGateway.Application.Dto.Payment.Sources;

    public class PaymentResponse
    {
        public string Id { get; set; }

        public string Reference { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }

        public Shipping Shipping { get; set; }

        public Source Source { get; set; }

        public Status Status { get; set; }
    }
}
