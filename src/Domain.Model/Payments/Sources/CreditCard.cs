namespace PaymentGateway.Domain.Model.Payments.Sources
{
    using Infrastructure.CrossCutting.Extensions;

    public class CreditCard : Source
    {
        public CreditCard(
            SourceType type,
            string number,
            int expiryMonth,
            int expiryYear,
            string name,
            string cvv,
            Billing billing) : base(type)
        {
            Number = number;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            Name = name;
            Cvv = cvv;
            Billing = billing;
        }

        public string Number { get; private set; }

        public int ExpiryMonth { get; private set; }

        public int ExpiryYear { get; private set; }

        public string Name { get; private set; }

        public string Cvv { get; private set; }

        public Billing Billing { get; set; }

        public override void MaskSensitiveData()
        {
            this.Number = this.Number.Mask(0, this.Number.Length - 1);
            this.Cvv = this.Cvv.Mask(0, this.Number.Length);
        }
    }
}
