namespace PaymentGateway.Gateway.MongoDB.Mappers.Payments.Sources
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;
    public static class BillingMapper
    {
        public static MongoDBModel.Sources.Billing ToMongoDBModel(this DomainModel.Sources.Billing billing) =>
            new()
            {
                Address = billing.Address.ToMongoDBModel(),
                PhoneNumber = billing.PhoneNumber,
            };

        public static DomainModel.Sources.Billing ToDomainModel(this MongoDBModel.Sources.Billing billing) =>
            new(billing.Address.ToDomainModel(), billing.PhoneNumber);
    }
}
