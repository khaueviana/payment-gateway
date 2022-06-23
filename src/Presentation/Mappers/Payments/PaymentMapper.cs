namespace PaymentGateway.Presentation.Mappers.Payments
{
    using PaymentGateway.Presentation.Mappers.Payments.Sources;
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class PaymentMapper
    {
        public static ApplicationDto.PaymentRequest ToApplicationDto(this PresentationDto.PaymentRequest paymentRequest) =>
            new()
            {
                Reference = paymentRequest.Reference,
                Currency = paymentRequest.Currency,
                Amount = paymentRequest.Amount,
                Description = paymentRequest.Description,
                Customer = paymentRequest.Customer.ToApplicationDto(),
                Shipping = paymentRequest.Shipping.ToApplicationDto(),
                Source = paymentRequest.Source.ToApplicationDto(),
            };

        public static PresentationDto.PaymentResponse ToPresentationDto(this ApplicationDto.PaymentResponse paymentResponse) =>
            new()
            {
                Id = paymentResponse.Id,
                Reference = paymentResponse.Reference,
                Currency = paymentResponse.Currency,
                Amount = paymentResponse.Amount,
                Description = paymentResponse.Description,
                Customer = paymentResponse.Customer.ToPresentationDto(),
                Shipping = paymentResponse.Shipping.ToPresentationDto(),
                Source = paymentResponse.Source.ToPresentationDto(),
                Status = (PresentationDto.Status)paymentResponse.Status
            };
    }
}

