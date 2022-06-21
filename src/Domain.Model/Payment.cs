namespace PaymentGateway.Domain.Model
{
    using PaymentGateway.Domain.Model.Sources;

    public class Payment
    {
        public string Id { get; }

        public string Reference { get; }

        public string Currency { get; }

        public decimal Amount { get; }

        public string Description { get; }

        public Customer Customer { get; }

        public Shipping Shipping { get; }

        public Source Source { get; }

        public Status Status { get; }
    }
}
