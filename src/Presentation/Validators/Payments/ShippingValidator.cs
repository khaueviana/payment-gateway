namespace PaymentGateway.Presentation.Validators.Payments
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments;

    public class ShippingValidator : AbstractValidator<Shipping>
    {
        public ShippingValidator()
        {
            this.RuleFor(entity => entity.Address).NotNull();
            this.RuleFor(entity => entity.Address).SetValidator(new ShippingAddressValidator());

            this.RuleFor(entity => entity.PhoneNumber).NotEmpty();
        }
    }
}
