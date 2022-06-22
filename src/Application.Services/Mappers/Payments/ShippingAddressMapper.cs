namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class ShippingAddressMapper
    {
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
