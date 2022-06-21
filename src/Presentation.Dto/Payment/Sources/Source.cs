namespace PaymentGateway.Presentation.Dto.Payment.Sources
{
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerSubType(typeof(CreditCard))]
    public abstract class Source
    {
        public SourceType Type { get; set; }
    }
}
