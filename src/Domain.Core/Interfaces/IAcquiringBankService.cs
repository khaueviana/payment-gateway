namespace PaymentGateway.Domain.Core.Interfaces
{
    using PaymentGateway.Domain.Model.Payments;
    using System.Threading.Tasks;

    public interface IAcquiringBankService
    {
        Task<bool> AuthorizeAsync(Payment payment);
    }
}
