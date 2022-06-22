namespace PaymentGateway.Domain.Model.Payments
{
    using PaymentGateway.Domain.Model.Payments.Sources;

    public class Payment
    {
        public Payment(Guid id,
                       string reference,
                       string currency,
                       decimal amount,
                       string description,
                       Customer customer,
                       Shipping shipping,
                       Source source,
                       Status status)
        {
            Id = id;
            Reference = reference;
            Currency = currency;
            Amount = amount;
            Description = description;
            Customer = customer;
            Shipping = shipping;
            Source = source;
            Status = status;
        }

        public Guid Id { get; }

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
