namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using ApplicationDto = Dto.Payments;
    using DomainModel = Domain.Model.Payments;

    public static class ShippingMapper
    {
        public static ApplicationDto.Shipping ToDto(this DomainModel.Shipping shipping) =>
            new()
            {
                Address = shipping.Address.ToDto(),
                PhoneNumber = shipping.PhoneNumber,
            };

        public static DomainModel.Shipping ToDomainModel(this ApplicationDto.Shipping shipping) =>
            new(shipping.Address.ToDomainModel(), shipping.PhoneNumber);
    }
}
