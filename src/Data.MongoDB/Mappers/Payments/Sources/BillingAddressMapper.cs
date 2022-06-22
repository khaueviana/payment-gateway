namespace PaymentGateway.Data.MongoDB.Mappers.Payments.Sources
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class BillingAddressMapper
    {
        public static MongoDBModel.Sources.BillingAddress ToMongoDBModel(this DomainModel.Sources.BillingAddress billingAddress)
        {
            if (billingAddress == null)
            {
                return null;
            }

            return new MongoDBModel.Sources.BillingAddress
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                City = billingAddress.City,
                Country = billingAddress.Country,
                State = billingAddress.State,
                Zip = billingAddress.Zip,
            };
        }

        public static DomainModel.Sources.BillingAddress ToDomainModel(this MongoDBModel.Sources.BillingAddress billingAddress)
        {
            if (billingAddress == null)
            {
                return null;
            }

            return new DomainModel.Sources.BillingAddress(billingAddress.AddressLine1,
                                                          billingAddress.AddressLine2,
                                                          billingAddress.City,
                                                          billingAddress.Country,
                                                          billingAddress.State,
                                                          billingAddress.Zip);
        }
    }
}
