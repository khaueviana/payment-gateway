namespace PaymentGateway.Application.Services
{
    using PaymentGateway.Application.Dto.Payments;
    using PaymentGateway.Application.Services.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        public Task<PaymentResponse> CreateAsync(PaymentRequest paymentRequest)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentResponse> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
