namespace PaymentGateway.Domain.Model.Payments
{
    public class Customer
    {
        public Customer(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }

        public string Name { get; }
    }
}
