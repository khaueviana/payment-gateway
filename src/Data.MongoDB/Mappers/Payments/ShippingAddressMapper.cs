namespace PaymentGateway.Data.MongoDB.Mappers.Payments
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class ShippingAddressMapper
    {
        public static MongoDBModel.ShippingAddress ToMongoDBModel(this DomainModel.ShippingAddress shippingAddress)
        {
            if (shippingAddress == null)
            {
                return null;
            }

            return new MongoDBModel.ShippingAddress
            {
                AddressLine1 = shippingAddress.AddressLine1,
                AddressLine2 = shippingAddress.AddressLine2,
                City = shippingAddress.City,
                Country = shippingAddress.Country,
                State = shippingAddress.State,
                Zip = shippingAddress.Zip,
            };
        }

        public static DomainModel.ShippingAddress ToDomainModel(this MongoDBModel.ShippingAddress shippingAddress)
        {
            if (shippingAddress == null)
            {
                return null;
            }

            return new DomainModel.ShippingAddress(shippingAddress.AddressLine1,
                                                   shippingAddress.AddressLine2,
                                                   shippingAddress.City,
                                                   shippingAddress.Country,
                                                   shippingAddress.State,
                                                   shippingAddress.Zip);
        }
    }
}
