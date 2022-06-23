namespace PaymentGateway.Presentation.Validators.Payments
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments;
    using PaymentGateway.Presentation.Validators.Payments.Sources;

    public class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            this.RuleFor(entity => entity.Reference).NotEmpty();
            this.RuleFor(entity => entity.Currency).NotEmpty();
            this.RuleFor(entity => entity.Amount).GreaterThan(0);
            this.RuleFor(entity => entity.Description).NotEmpty();

            this.RuleFor(entity => entity.Customer).NotNull();
            this.RuleFor(entity => entity.Customer).SetValidator(new CustomerValidator());

            this.RuleFor(entity => entity.Shipping).NotNull();
            this.RuleFor(entity => entity.Shipping).SetValidator(new ShippingValidator());

            this.RuleFor(entity => entity.Source).NotNull();
            this.RuleFor(entity => entity.Source).SetInheritanceValidator(v =>
            {
                v.Add(new CreditCardValidator());
            });
        }
    }
}
