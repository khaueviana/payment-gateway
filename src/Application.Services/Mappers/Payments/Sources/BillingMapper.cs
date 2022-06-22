namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class BillingMapper
    {
        public static ApplicationDto.Sources.Billing ToDto(this DomainModel.Sources.Billing billing)
        {
            if (billing == null)
            {
                return null;
            }

            return new ApplicationDto.Sources.Billing
            {
                Address = billing.Address.ToDto(),
                PhoneNumber = billing.PhoneNumber,
            };
        }

        public static DomainModel.Sources.Billing ToDomainModel(this ApplicationDto.Sources.Billing billing)
        {
            if (billing == null)
            {
                return null;
            }

            return new DomainModel.Sources.Billing(billing.Address.ToDomainModel(), billing.PhoneNumber);
        }
    }
}
