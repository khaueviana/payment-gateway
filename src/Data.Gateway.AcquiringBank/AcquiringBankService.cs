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

        public Task CreatePaymentAsync(DomainModel.Payment payment)
        {
            return acquiringBankApi.CreatePaymentAsync(payment.ToDto());
        }
    }
}
