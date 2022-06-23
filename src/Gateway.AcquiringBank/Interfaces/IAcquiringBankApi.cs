namespace PaymentGateway.Gateway.AcquiringBank.Interfaces
{
    using PaymentGateway.Gateway.AcquiringBank.Dto;
    using Refit;
    using System.Threading.Tasks;

    public interface IAcquiringBankApi
    {
        [Post("/v1/payments/")]
        Task<PaymentResponse> AuthorizeAsync([Body(BodySerializationMethod.UrlEncoded)] PaymentRequest paymentRequest);
    }
}
