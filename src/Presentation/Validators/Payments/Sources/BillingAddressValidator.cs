namespace PaymentGateway.Presentation.Validators.Payments
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments.Sources;

    public class BillingAddressValidator : AbstractValidator<BillingAddress>
    {
        public BillingAddressValidator()
        {
            this.RuleFor(entity => entity.AddressLine1).NotEmpty();
            this.RuleFor(entity => entity.City).NotEmpty();
            this.RuleFor(entity => entity.State).NotEmpty();
            this.RuleFor(entity => entity.Zip).NotEmpty();
            this.RuleFor(entity => entity.Country).NotEmpty();
        }
    }
}
