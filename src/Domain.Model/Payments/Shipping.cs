namespace PaymentGateway.Domain.Model.Payments
{
    public class Shipping
    {
        public Shipping(ShippingAddress address, string phoneNumber)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public ShippingAddress Address { get; }

        public string PhoneNumber { get; }
    }
}
