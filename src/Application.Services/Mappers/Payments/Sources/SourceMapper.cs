namespace PaymentGateway.Application.Services.Mappers.Payments.Sources
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class SourceMapper
    {
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
