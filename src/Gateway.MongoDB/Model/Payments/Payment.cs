namespace PaymentGateway.Gateway.MongoDB.Model.Payments
{
    using PaymentGateway.Gateway.MongoDB.Attributes;
    using PaymentGateway.Gateway.MongoDB.Model.Payments.Sources;

    [BsonCollection("payments")]
    public class Payment : Document
    {
        public string Reference { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }

        public Shipping Shipping { get; set; }

        public Source Source { get; set; }

        public int Status { get; set; }
    }
}
