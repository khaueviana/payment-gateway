namespace PaymentGateway.Data.AcquiringBank.Interfaces
{
    using PaymentGateway.Data.AcquiringBank.Dto;
    using Refit;
    using System.Threading.Tasks;

    public interface IAcquiringBankApi
    {
        [Post("/v1/payments")]
        Task CreatePaymentAsync([Body(BodySerializationMethod.UrlEncoded)] Payment payment);
    }
}
