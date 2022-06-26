namespace PaymentGateway.Gateway.MongoDB.Mappers.Payments.Sources
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class SourceMapper
    {
        public static MongoDBModel.Sources.Source ToMongoDBModel(this DomainModel.Sources.Source source) =>
            source switch
            {
                DomainModel.Sources.CreditCard creditCard => new()
                {
                    Type = (int)creditCard.Type,
                    Number = creditCard.Number,
                    ExpiryMonth = creditCard.ExpiryMonth,
                    ExpiryYear = creditCard.ExpiryYear,
                    Name = creditCard.Name,
                    Cvv = creditCard.Cvv,
                    Billing = creditCard.Billing.ToMongoDBModel(),
                },
                _ => null,
            };

        public static DomainModel.Sources.Source ToDomainModel(this MongoDBModel.Sources.Source source) =>
            source.Type switch
            {
                (int)DomainModel.Sources.SourceType.CreditCard => new DomainModel.Sources.CreditCard(source.Number,
                                                                                                     source.ExpiryMonth,
                                                                                                     source.ExpiryYear,
                                                                                                     source.Name,
                                                                                                     source.Cvv,
                                                                                                     source.Billing.ToDomainModel()),
                _ => null,
            };
    }
}
