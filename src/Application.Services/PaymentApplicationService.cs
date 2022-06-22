namespace PaymentGateway.Application.Services
{
    using PaymentGateway.Application.Services.Interfaces;
    using PaymentGateway.Domain.Core.Interfaces;
    using System;
    using System.Threading.Tasks;
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IAcquiringBankService acquiringBankService;
        private readonly IPaymentsRepository paymentsRepository;

        public PaymentApplicationService(IAcquiringBankService acquiringBankService, IPaymentsRepository paymentsRepository)
        {
            this.acquiringBankService = acquiringBankService;
            this.paymentsRepository = paymentsRepository;
        }

        public Task<ApplicationDto.PaymentResponse> CreateAsync(ApplicationDto.PaymentRequest paymentRequest)
        {
            var customer = new DomainModel.Customer(paymentRequest.Customer.Id, paymentRequest.Customer.Name);
            var shippingAddress = new DomainModel.ShippingAddress(paymentRequest.Shipping.Address.AddressLine1, )

            var payment = new DomainModel.Payment(paymentRequest.Reference,
                                                  paymentRequest.Currency,
                                                  paymentRequest.Amount,
                                                  paymentRequest.Description,
                                                  customer,
                                                  );
        }

        public Task<ApplicationDto.PaymentResponse> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
