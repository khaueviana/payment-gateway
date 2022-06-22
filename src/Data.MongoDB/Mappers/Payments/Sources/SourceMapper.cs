namespace PaymentGateway.Data.MongoDB.Mappers.Payments.Sources
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class SourceMapper
    {
        public static MongoDBModel.Sources.Source ToMongoDBModel(this DomainModel.Sources.Source source)
        {
            if (source == null)
            {
                return null;
            }

            return source switch
            {
                DomainModel.Sources.CreditCard creditCard => new MongoDBModel.Sources.Source
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
        }

        public static DomainModel.Sources.Source ToDomainModel(this MongoDBModel.Sources.Source source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Type switch
            {
                1 => new DomainModel.Sources.CreditCard((DomainModel.Sources.SourceType)source.Type,
                                                        source.Number,
                                                        source.ExpiryMonth,
                                                        source.ExpiryYear,
                                                        source.Name,
                                                        source.Cvv,
                                                        source.Billing.ToDomainModel()),
                _ => null,
            };
        }
    }
}
