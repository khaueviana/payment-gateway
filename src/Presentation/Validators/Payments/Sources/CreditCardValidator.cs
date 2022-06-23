namespace PaymentGateway.Presentation.Validators.Payments.Sources
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments.Sources;

    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            this.RuleFor(entity => entity.Type).Equal(SourceType.CreditCard);
            this.RuleFor(entity => entity.Number).NotEmpty();
            this.RuleFor(entity => entity.ExpiryMonth).GreaterThan(0);
            this.RuleFor(entity => entity.ExpiryYear).GreaterThan(0);
            this.RuleFor(entity => entity.Name).NotEmpty();
            this.RuleFor(entity => entity.Cvv).NotEmpty();

            this.RuleFor(entity => entity.Billing).NotNull();
            this.RuleFor(entity => entity.Billing).SetValidator(new BillingValidator());
        }
    }
}