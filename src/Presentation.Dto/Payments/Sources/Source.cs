namespace PaymentGateway.Presentation.Dto.Payments.Sources
{
    using PaymentGateway.Presentation.Dto.Converters;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Text.Json.Serialization;

    [SwaggerSubType(typeof(CreditCard))]
    [JsonConverter(typeof(SourceJsonConverter))]
    public abstract class Source
    {
        //[JsonConverter(typeof(StringEnumConverter))]
        public SourceType Type { get; set; }
    }
}
