namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class BillingAddressMapper
    {
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
