﻿namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class SourceMapper
    {
        public static ApplicationDto.Sources.Source ToDto(this DomainModel.Sources.Source source)
        {
            if (source == null)
            {
                return null;
            }

            return source switch
            {
                DomainModel.Sources.CreditCard creditCard => new ApplicationDto.Sources.CreditCard
                {
                    Type = (ApplicationDto.Sources.SourceType)creditCard.Type,
                    Number = creditCard.Number,
                    ExpiryMonth = creditCard.ExpiryMonth,
                    ExpiryYear = creditCard.ExpiryYear,
                    Name = creditCard.Name,
                    Cvv = creditCard.Cvv,
                    Billing = creditCard.Billing.ToDto(),
                },
                _ => null,
            };
        }

        public static DomainModel.Sources.Source ToDomainModel(this ApplicationDto.Sources.Source source)
        {
            if (source == null)
            {
                return null;
            }

            return source switch
            {
                ApplicationDto.Sources.CreditCard creditCard => new DomainModel.Sources.CreditCard((DomainModel.Sources.SourceType)creditCard.Type,
                                                                                                    creditCard.Number,
                                                                                                    creditCard.ExpiryMonth,
                                                                                                    creditCard.ExpiryYear,
                                                                                                    creditCard.Name,
                                                                                                    creditCard.Cvv,
                                                                                                    creditCard.Billing.ToDomainModel()),
                _ => null,
            };
        }
    }
}
