namespace PaymentGateway.Presentation.Mappers.Payments.Sources
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class BillingMapper
    {
        public static ApplicationDto.Sources.Billing ToApplicationDto(this PresentationDto.Sources.Billing billing) =>
            new()
            {
                Address = billing.Address.ToApplicationDto(),
                PhoneNumber = billing.PhoneNumber,
            };

        public static PresentationDto.Sources.Billing ToPresentationDto(this ApplicationDto.Sources.Billing billing) =>
            new()
            {
                Address = billing.Address.ToPresentationDto(),
                PhoneNumber = billing.PhoneNumber,
            };
    }
}
