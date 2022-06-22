namespace PaymentGateway.Presentation.Mappers.Payments.Sources
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class SourceMapper
    {
        public static ApplicationDto.Sources.Source ToApplicationDto(this PresentationDto.Sources.Source source)
        {
            if (source == null)
            {
                return null;
            }

            return source switch
            {
                PresentationDto.Sources.CreditCard creditCard => new ApplicationDto.Sources.CreditCard
                {
                    Type = (ApplicationDto.Sources.SourceType)creditCard.Type,
                    Number = creditCard.Number,
                    ExpiryMonth = creditCard.ExpiryMonth,
                    ExpiryYear = creditCard.ExpiryYear,
                    Name = creditCard.Name,
                    Cvv = creditCard.Cvv,
                    Billing = creditCard.Billing.ToApplicationDto(),
                },
                _ => null,
            };
        }
    }
}
