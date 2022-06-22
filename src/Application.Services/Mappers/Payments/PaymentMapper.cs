namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using PaymentGateway.Application.Services.Mappers.Payments.Sources;
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class PaymentMapper
    {
        public static ApplicationDto.PaymentResponse ToDto(this DomainModel.Payment payment)
        {
            if (payment == null)
            {
                return null;
            }

            return new ApplicationDto.PaymentResponse
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
        }

        public static DomainModel.Payment ToDomainModel(this ApplicationDto.PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
            {
                return null;
            }

            return new DomainModel.Payment(paymentRequest.Reference,
                                           paymentRequest.Currency,
                                           paymentRequest.Amount,
                                           paymentRequest.Description,
                                           paymentRequest.Customer.ToDomainModel(),
                                           paymentRequest.Shipping.ToDomainModel(),
                                           paymentRequest.Source.ToDomainModel());
        }
    }
}
