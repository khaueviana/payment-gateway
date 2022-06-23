namespace PaymentGateway.Presentation.Validators.Payments.Sources
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments.Sources;

    public class BillingValidator : AbstractValidator<Billing>
    {
        public BillingValidator()
        {
            this.RuleFor(entity => entity.Address).NotNull();
            this.RuleFor(entity => entity.Address).SetValidator(new BillingAddressValidator());

            this.RuleFor(entity => entity.PhoneNumber).NotEmpty();
        }
    }
}
