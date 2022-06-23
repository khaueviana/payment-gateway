namespace PaymentGateway.Presentation.Mappers.Payments
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class ShippingMapper
    {
        public static ApplicationDto.Shipping ToApplicationDto(this PresentationDto.Shipping shipping) =>
            new()
            {
                Address = shipping.Address.ToApplicationDto(),
                PhoneNumber = shipping.PhoneNumber,
            };

        public static PresentationDto.Shipping ToPresentationDto(this ApplicationDto.Shipping shipping) =>
            new()
            {
                Address = shipping.Address.ToPresentationDto(),
                PhoneNumber = shipping.PhoneNumber,
            };
    }
}
