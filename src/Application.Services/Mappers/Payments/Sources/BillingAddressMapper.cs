namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class BillingAddressMapper
    {
        public static ApplicationDto.Sources.BillingAddress ToDto(this DomainModel.Sources.BillingAddress billingAddress)
        {
            if (billingAddress == null)
            {
                return null;
            }

            return new ApplicationDto.Sources.BillingAddress
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                City = billingAddress.City,
                Country = billingAddress.Country,
                State = billingAddress.State,
                Zip = billingAddress.Zip,
            };
        }
        public static DomainModel.Sources.BillingAddress ToDomainModel(this ApplicationDto.Sources.BillingAddress billingAddress)
        {
            if (billingAddress == null)
            {
                return null;
            }

            return new DomainModel.Sources.BillingAddress(billingAddress.AddressLine1,
                                                          billingAddress.AddressLine2,
                                                          billingAddress.City,
                                                          billingAddress.Country,
                                                          billingAddress.State,
                                                          billingAddress.Zip);
        }
    }
}
