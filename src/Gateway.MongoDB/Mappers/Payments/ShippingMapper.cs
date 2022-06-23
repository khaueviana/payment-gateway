namespace PaymentGateway.Gateway.MongoDB.Mappers.Payments
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class ShippingMapper
    {
        public static MongoDBModel.Shipping ToMongoDBModel(this DomainModel.Shipping shipping) =>
            new()
            {
                Address = shipping.Address.ToMongoDBModel(),
                PhoneNumber = shipping.PhoneNumber,
            };

        public static DomainModel.Shipping ToDomainModel(this MongoDBModel.Shipping shipping) =>
            new(shipping.Address.ToDomainModel(), shipping.PhoneNumber);
    }
}
