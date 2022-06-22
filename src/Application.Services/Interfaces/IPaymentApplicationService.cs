namespace PaymentGateway.Application.Services.Interfaces
{
    using PaymentGateway.Application.Dto.Payments;

    public interface IPaymentApplicationService
    {
        Task<PaymentResponse> CreateAsync(PaymentRequest paymentRequest);

        Task<PaymentResponse> GetAsync(Guid id);
    }
}
