namespace PaymentGateway.Gateway.MongoDB.Repositories
{
    using global::MongoDB.Driver;
    using PaymentGateway.Domain.Core.Interfaces;
    using PaymentGateway.Gateway.MongoDB.Attributes.Repositories;
    using PaymentGateway.Gateway.MongoDB.Mappers.Payments;
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

        public async Task<DomainModel.Payment> GetByReference(string reference)
        {
            var model = await this.FindOneAsync(x => x.Reference == reference);
            return model.ToDomainModel();
        }
    }
}
