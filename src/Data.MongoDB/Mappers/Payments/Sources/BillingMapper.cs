namespace PaymentGateway.Data.MongoDB.Mappers.Payments.Sources
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;
    public static class BillingMapper
    {
        public static MongoDBModel.Sources.Billing ToMongoDBModel(this DomainModel.Sources.Billing billing)
        {
            if (billing == null)
            {
                return null;
            }

            return new MongoDBModel.Sources.Billing
            {
                Address = billing.Address.ToMongoDBModel(),
                PhoneNumber = billing.PhoneNumber,
            };
        }

        public static DomainModel.Sources.Billing ToDomainModel(this MongoDBModel.Sources.Billing billing)
        {
            if (billing == null)
            {
                return null;
            }

            return new DomainModel.Sources.Billing(billing.Address.ToDomainModel(), billing.PhoneNumber);
        }
    }
}
