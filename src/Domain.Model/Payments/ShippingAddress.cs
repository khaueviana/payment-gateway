namespace PaymentGateway.Domain.Model.Payments
{
    public class ShippingAddress
    {
        public ShippingAddress(string addressLine1, string addressLine2, string city, string state, string zip, string country)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }

        public string AddressLine1 { get; }

        public string AddressLine2 { get; }

        public string City { get; }

        public string State { get; }

        public string Zip { get; }

        public string Country { get; }
    }
}
