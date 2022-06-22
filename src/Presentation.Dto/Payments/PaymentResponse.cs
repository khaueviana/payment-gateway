namespace PaymentGateway.Presentation.Dto.Payments
{
    using PaymentGateway.Presentation.Dto.Payments.Sources;

    public class PaymentResponse
    {
        public Guid Id { get; set; }

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
