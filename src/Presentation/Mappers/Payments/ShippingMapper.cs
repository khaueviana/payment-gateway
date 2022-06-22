namespace PaymentGateway.Presentation.Mappers.Payments
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class ShippingMapper
    {
        public static ApplicationDto.Shipping ToApplicationDto(this PresentationDto.Shipping shipping)
        {
            if (shipping == null)
            {
                return null;
            }

            return new ApplicationDto.Shipping
            {
                Address = shipping.Address.ToApplicationDto(),
                PhoneNumber = shipping.PhoneNumber,
            };
        }
    }
}
