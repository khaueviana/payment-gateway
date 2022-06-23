namespace PaymentGateway.Data.AcquiringBank
{
    using PaymentGateway.Data.AcquiringBank.Interfaces;
    using PaymentGateway.Data.AcquiringBank.Mappers;
    using PaymentGateway.Domain.Core.Interfaces;
    using System.Threading.Tasks;
    using DomainModel = Domain.Model.Payments;

    internal class AcquiringBankService : IAcquiringBankService
    {
        private readonly IAcquiringBankApi acquiringBankApi;

        public AcquiringBankService(IAcquiringBankApi acquiringBankApi)
        {
            this.acquiringBankApi = acquiringBankApi;
        }

        public async Task<bool> AuthorizeAsync(DomainModel.Payment payment)
        {
            var response = await acquiringBankApi.AuthorizeAsync(payment.ToDto());
            return response.IsAuthorized;
        }
    }
}
