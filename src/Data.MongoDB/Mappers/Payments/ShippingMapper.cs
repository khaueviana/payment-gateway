namespace PaymentGateway.Data.MongoDB.Mappers.Payments
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;
    public static class ShippingMapper
    {
        public static MongoDBModel.Shipping ToMongoDBModel(this DomainModel.Shipping shipping)
        {
            if (shipping == null)
            {
                return null;
            }

            return new MongoDBModel.Shipping
            {
                Address = shipping.Address.ToMongoDBModel(),
                PhoneNumber = shipping.PhoneNumber,
            };
        }

        public static DomainModel.Shipping ToDomainModel(this MongoDBModel.Shipping shipping)
        {
            if (shipping == null)
            {
                return null;
            }

            return new DomainModel.Shipping(shipping.Address.ToDomainModel(), shipping.PhoneNumber);
        }
    }
}
