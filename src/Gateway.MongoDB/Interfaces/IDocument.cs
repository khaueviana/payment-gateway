namespace PaymentGateway.Gateway.MongoDB.Interfaces
{
    using System;

    public interface IDocument
    {
        public Guid Id { get; set; }

        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset UpdatedAt { get; set; }
    }
}
