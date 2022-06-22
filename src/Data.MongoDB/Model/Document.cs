namespace PaymentGateway.Data.MongoDB.Model
{
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;
    using PaymentGateway.Data.MongoDB.Interfaces;
    using System;

    public class Document : IDocument
    {
        protected Document()
        {
        }

        public Guid Id { get; set; }

        [BsonRepresentation(BsonType.Document)]
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonRepresentation(BsonType.Document)]
        public DateTimeOffset UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
