namespace PaymentGateway.Domain.Model.Payments.Sources
{
    using Infrastructure.CrossCutting.Extensions;

    public class CreditCard : Source
    {
        public CreditCard(
            string number,
            int expiryMonth,
            int expiryYear,
            string name,
            string cvv,
            Billing billing) : base(SourceType.CreditCard)
        {
            this.Number = number;
            this.ExpiryMonth = expiryMonth;
            this.ExpiryYear = expiryYear;
            this.Name = name;
            this.Cvv = cvv;
            this.Billing = billing;
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
            this.Cvv = this.Cvv.Mask(0, this.Cvv.Length);
        }
    }
}
