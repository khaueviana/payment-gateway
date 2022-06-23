namespace PaymentGateway.Gateway.MongoDB.Mappers.Payments
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class CustomerMapper
    {
        public static MongoDBModel.Customer ToMongoDBModel(this DomainModel.Customer customer) =>
            new()
            {
                Id = customer.Id,
                Name = customer.Name,
            };

        public static DomainModel.Customer ToDomainModel(this MongoDBModel.Customer customer) =>
            new DomainModel.Customer(customer.Id, customer.Name);
    }
}
