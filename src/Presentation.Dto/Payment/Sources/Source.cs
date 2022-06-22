namespace PaymentGateway.Presentation.Dto.Payment.Sources
{
    using PaymentGateway.Presentation.Dto.Converters;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Text.Json.Serialization;

    [SwaggerSubType(typeof(CreditCard))]
    [JsonConverter(typeof(SourceJsonConverter))]
    public abstract class Source
    {
        public SourceType Type { get; set; }
    }
}
