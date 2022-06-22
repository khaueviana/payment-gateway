namespace PaymentGateway.Presentation.Mappers.Payments
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class ShippingAddressMapper
    {
        public static ApplicationDto.ShippingAddress ToApplicationDto(this PresentationDto.ShippingAddress shippingAddress)
        {
            if (shippingAddress == null)
            {
                return null;
            }

            return new ApplicationDto.ShippingAddress
            {
                AddressLine1 = shippingAddress.AddressLine1,
                AddressLine2 = shippingAddress.AddressLine2,
                City = shippingAddress.City,
                Country = shippingAddress.Country,
                State = shippingAddress.State,
                Zip = shippingAddress.Zip,
            };
        }
    }
}
