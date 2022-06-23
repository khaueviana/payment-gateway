namespace PaymentGateway.Domain.Model.Payments.Sources
{
    public abstract class Source
    {
        protected Source(SourceType type)
        {
            Type = type;
        }

        public SourceType Type { get; }

        public abstract void MaskSensitiveData();
    }
}
