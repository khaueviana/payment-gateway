namespace PaymentGateway.Domain.Model.Payments.Sources
{
    public class Billing
    {
        public Billing(BillingAddress address, string phoneNumber)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public BillingAddress Address { get; }

        public string PhoneNumber { get; }
    }
}
