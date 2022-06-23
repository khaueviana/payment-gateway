namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using PaymentGateway.Application.Services.Mappers.Payments.Sources;
    using ApplicationDto = Dto.Payments;
    using DomainModel = Domain.Model.Payments;

    public static class PaymentMapper
    {
        public static ApplicationDto.PaymentResponse ToDto(this DomainModel.Payment payment) =>
            new()
            {
                Id = payment.Id,
                Reference = payment.Reference,
                Currency = payment.Currency,
                Amount = payment.Amount,
                Description = payment.Description,
                Customer = payment.Customer.ToDto(),
                Shipping = payment.Shipping.ToDto(),
                Source = payment.Source.ToDto(),
                Status = (ApplicationDto.Status)payment.Status,
            };

        public static DomainModel.Payment ToDomainModel(this ApplicationDto.PaymentRequest paymentRequest) =>
            new(paymentRequest.Reference,
                paymentRequest.Currency,
                paymentRequest.Amount,
                paymentRequest.Description,
                paymentRequest.Customer.ToDomainModel(),
                paymentRequest.Shipping.ToDomainModel(),
                paymentRequest.Source.ToDomainModel());
    }
}
