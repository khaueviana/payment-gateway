﻿namespace PaymentGateway.Presentation.Mappers.Payments
{
    using PaymentGateway.Presentation.Mappers.Payments.Sources;
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class PaymentMapper
    {
        public static ApplicationDto.PaymentRequest ToApplicationDto(this PresentationDto.PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
            {
                return null;
            }

            return new ApplicationDto.PaymentRequest
            {
                Reference = paymentRequest.Reference,
                Currency = paymentRequest.Currency,
                Amount = paymentRequest.Amount,
                Description = paymentRequest.Description,
                Customer = paymentRequest.Customer.ToApplicationDto(),
                Shipping = paymentRequest.Shipping.ToApplicationDto(),
                Source = paymentRequest.Source.ToApplicationDto(),
            };
        }
    }
}
