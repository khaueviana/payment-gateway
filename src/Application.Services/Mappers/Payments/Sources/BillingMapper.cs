namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = Dto.Payments;
    using DomainModel = Domain.Model.Payments;

    public static class BillingMapper
    {
        public static ApplicationDto.Sources.Billing ToDto(this DomainModel.Sources.Billing billing) =>
            new()
            {
                Address = billing.Address.ToDto(),
                PhoneNumber = billing.PhoneNumber,
            };

        public static DomainModel.Sources.Billing ToDomainModel(this ApplicationDto.Sources.Billing billing) =>
            new(billing.Address.ToDomainModel(), billing.PhoneNumber);
    }
}
