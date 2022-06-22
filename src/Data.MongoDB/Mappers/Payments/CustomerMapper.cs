namespace PaymentGateway.Data.MongoDB.Mappers.Payments
{
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;

    public static class CustomerMapper
    {
        public static MongoDBModel.Customer ToMongoDBModel(this DomainModel.Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new MongoDBModel.Customer
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }

        public static DomainModel.Customer ToDomainModel(this MongoDBModel.Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new DomainModel.Customer(customer.Id, customer.Name);
        }
    }
}
