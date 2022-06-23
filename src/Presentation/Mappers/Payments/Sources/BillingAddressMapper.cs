namespace PaymentGateway.Presentation.Mappers.Payments.Sources
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class BillingAddressMapper
    {
        public static ApplicationDto.Sources.BillingAddress ToApplicationDto(this PresentationDto.Sources.BillingAddress billingAddress) =>
            new()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                City = billingAddress.City,
                Country = billingAddress.Country,
                State = billingAddress.State,
                Zip = billingAddress.Zip,
            };

        public static PresentationDto.Sources.BillingAddress ToPresentationDto(this ApplicationDto.Sources.BillingAddress billingAddress) =>
            new()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                City = billingAddress.City,
                Country = billingAddress.Country,
                State = billingAddress.State,
                Zip = billingAddress.Zip,
            };
    }
}
