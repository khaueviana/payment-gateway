namespace PaymentGateway.Gateway.AcquiringBank
{
    using PaymentGateway.Domain.Core.Interfaces;
    using PaymentGateway.Gateway.AcquiringBank.Interfaces;
    using PaymentGateway.Gateway.AcquiringBank.Mappers;
    using System.Threading.Tasks;
    using DomainModel = Domain.Model.Payments;

    public class AcquiringBankService : IAcquiringBankService
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
