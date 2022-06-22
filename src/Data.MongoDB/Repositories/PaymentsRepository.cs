namespace PaymentGateway.Data.MongoDB.Repositories
{
    using global::MongoDB.Driver;
    using PaymentGateway.Data.MongoDB.Attributes.Repositories;
    using PaymentGateway.Data.MongoDB.Mappers.Payments;
    using PaymentGateway.Domain.Core.Interfaces;
    using System;
    using System.Threading.Tasks;
    using DomainModel = Domain.Model.Payments;
    using MongoDBModel = Model.Payments;


    public class PaymentsRepository : BaseRepository<MongoDBModel.Payment>, IPaymentsRepository
    {
        public PaymentsRepository(IMongoDatabase database) : base(database)
        {
        }

        public Task InsertAsync(DomainModel.Payment payment)
        {
            return this.InsertOneAsync(payment.ToMongoDBModel());
        }

        public async Task<DomainModel.Payment> GetByIdAsync(Guid id)
        {
            var model = await this.FindByIdAsync(id);
            return model.ToDomainModel();
        }
    }
}
