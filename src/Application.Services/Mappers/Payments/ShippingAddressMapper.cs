namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class ShippingAddressMapper
    {
        public static ApplicationDto.ShippingAddress ToDto(this DomainModel.ShippingAddress shippingAddress)
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

        public static DomainModel.ShippingAddress ToDomainModel(this ApplicationDto.ShippingAddress shippingAddress)
        {
            if (shippingAddress == null)
            {
                return null;
            }

            return new DomainModel.ShippingAddress(shippingAddress.AddressLine1,
                                                   shippingAddress.AddressLine2,
                                                   shippingAddress.City,
                                                   shippingAddress.Country,
                                                   shippingAddress.State,
                                                   shippingAddress.Zip);
        }
    }
}
