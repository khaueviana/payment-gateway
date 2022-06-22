namespace PaymentGateway.Domain.Core.Interfaces
{
    using PaymentGateway.Domain.Model.Payments;
    using System;
    using System.Threading.Tasks;

    public interface IPaymentsRepository
    {
        Task InsertAsync(Payment payment);

        Task<Payment> GetByIdAsync(Guid id);
    }
}
