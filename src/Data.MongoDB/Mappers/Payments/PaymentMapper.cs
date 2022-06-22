namespace PaymentGateway.Data.MongoDB.Mappers.Payments
{
    using PaymentGateway.Data.MongoDB.Mappers.Payments.Sources;
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class PaymentMapper
    {
        public static MongoDBModel.Payment ToMongoDBModel(this DomainModel.Payment payment)
        {
            if (payment == null)
            {
                return null;
            }

            return new MongoDBModel.Payment
            {
                Id = payment.Id,
                Reference = payment.Reference,
                Currency = payment.Currency,
                Amount = payment.Amount,
                Description = payment.Description,
                Customer = payment.Customer.ToMongoDBModel(),
                Shipping = payment.Shipping.ToMongoDBModel(),
                Source = payment.Source.ToMongoDBModel(),
                Status = (int)payment.Status,
            };
        }

        public static DomainModel.Payment ToDomainModel(this MongoDBModel.Payment payment)
        {
            if (payment == null)
            {
                return null;
            }

            return new DomainModel.Payment(payment.Id,
                                           payment.Reference,
                                           payment.Currency,
                                           payment.Amount,
                                           payment.Description,
                                           payment.Customer.ToDomainModel(),
                                           payment.Shipping.ToDomainModel(),
                                           payment.Source.ToDomainModel(),
                                           (DomainModel.Status)payment.Status);
        }
    }
}
