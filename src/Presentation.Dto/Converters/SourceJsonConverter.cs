namespace PaymentGateway.Presentation.Dto.Converters
{
    using PaymentGateway.Presentation.Dto.Payments.Sources;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class SourceJsonConverter : JsonConverter<Source>
    {
        private const string CreditCardSourceType = "CreditCard";
        private const string TypeProperty = "type";

        public override Source Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerClone = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref readerClone);

            if (!jsonDocument.RootElement.TryGetProperty(TypeProperty, out var typeProperty))
            {
                throw new JsonException();
            }

            return typeProperty.GetString() switch
            {
                CreditCardSourceType => JsonSerializer.Deserialize<CreditCard>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
        {
            var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            var json = value.Type switch
            {
                SourceType.CreditCard => JsonSerializer.Serialize(value as CreditCard, jsonSerializerOptions),
                _ => string.Empty
            };

            writer.WriteRawValue(json);
        }
    }
}
