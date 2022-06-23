namespace PaymentGateway.Gateway.MongoDB.Mappers.Payments.Sources
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class BillingAddressMapper
    {
        public static MongoDBModel.Sources.BillingAddress ToMongoDBModel(this DomainModel.Sources.BillingAddress billingAddress) =>
            new()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                City = billingAddress.City,
                Country = billingAddress.Country,
                State = billingAddress.State,
                Zip = billingAddress.Zip,
            };

        public static DomainModel.Sources.BillingAddress ToDomainModel(this MongoDBModel.Sources.BillingAddress billingAddress) =>
            new(billingAddress.AddressLine1,
                billingAddress.AddressLine2,
                billingAddress.City,
                billingAddress.Country,
                billingAddress.State,
                billingAddress.Zip);
    }
}
