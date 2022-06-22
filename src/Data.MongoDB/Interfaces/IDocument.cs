namespace PaymentGateway.Data.MongoDB.Interfaces
{
    using System;

    public interface IDocument
    {
        public Guid Id { get; set; }

        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset UpdatedAt { get; set; }
    }
}
