namespace PaymentGateway.Gateway.AcquiringBank.Mappers
{
    using DomainModel = Domain.Model.Payments;

    public static class PaymentMapper
    {
        public static Dto.PaymentRequest ToDto(this DomainModel.Payment payment)
        {
            var creditCard = payment.Source as DomainModel.Sources.CreditCard;

            return new Dto.PaymentRequest
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
