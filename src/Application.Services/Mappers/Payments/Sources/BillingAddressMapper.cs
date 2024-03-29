﻿namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = Dto.Payments;
    using DomainModel = Domain.Model.Payments;

    public static class BillingAddressMapper
    {
        public static ApplicationDto.Sources.BillingAddress ToDto(this DomainModel.Sources.BillingAddress billingAddress) =>
            new()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                City = billingAddress.City,
                Country = billingAddress.Country,
                State = billingAddress.State,
                Zip = billingAddress.Zip,
            };

        public static DomainModel.Sources.BillingAddress ToDomainModel(this ApplicationDto.Sources.BillingAddress billingAddress) =>
            new(billingAddress.AddressLine1,
                billingAddress.AddressLine2,
                billingAddress.City,
                billingAddress.Country,
                billingAddress.State,
                billingAddress.Zip);
    }
}
