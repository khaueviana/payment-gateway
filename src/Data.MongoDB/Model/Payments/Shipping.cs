namespace PaymentGateway.Data.MongoDB.Model.Payments
{
    public class Shipping
    {
        public ShippingAddress Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
