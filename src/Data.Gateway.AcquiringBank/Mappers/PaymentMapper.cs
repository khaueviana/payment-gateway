namespace PaymentGateway.Data.AcquiringBank.Mappers
{
    using DomainModel = Domain.Model.Payments;
    using Dto = Data.AcquiringBank.Dto;

    public static class PaymentMapper
    {
        public static Dto.Payment ToDto(this DomainModel.Payment payment)
        {
            if (payment == null)
            {
                return null;
            }

            var creditCard = payment.Source as DomainModel.Sources.CreditCard;

            if (creditCard == null)
            {
                return null;
            }

            return new Dto.Payment
            {
                Number = creditCard.Number,
                ExpiryMonth = creditCard.ExpiryMonth,
                ExpiryYear = creditCard.ExpiryYear,
                Name = creditCard.Name,
                Cvv = creditCard.Cvv,
            };
        }
    }
}
