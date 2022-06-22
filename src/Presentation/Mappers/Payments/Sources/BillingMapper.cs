namespace PaymentGateway.Presentation.Mappers.Payments.Sources
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class BillingMapper
    {
        public static ApplicationDto.Sources.Billing ToApplicationDto(this PresentationDto.Sources.Billing billing)
        {
            if (billing == null)
            {
                return null;
            }

            return new ApplicationDto.Sources.Billing
            {
                Address = billing.Address.ToApplicationDto(),
                PhoneNumber = billing.PhoneNumber,
            };
        }
    }
}
