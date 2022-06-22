namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class ShippingMapper
    {
        public static ApplicationDto.Shipping ToDto(this DomainModel.Shipping shipping)
        {
            if (shipping == null)
            {
                return null;
            }

            return new ApplicationDto.Shipping
            {
                Address = shipping.Address.ToDto(),
                PhoneNumber = shipping.PhoneNumber,
            };
        }

        public static DomainModel.Shipping ToDomainModel(this ApplicationDto.Shipping shipping)
        {
            if (shipping == null)
            {
                return null;
            }

            return new DomainModel.Shipping(shipping.Address.ToDomainModel(), shipping.PhoneNumber);
        }
    }
}
