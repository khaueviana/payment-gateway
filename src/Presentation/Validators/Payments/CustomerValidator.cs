namespace PaymentGateway.Presentation.Validators.Payments
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments;

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            this.RuleFor(entity => entity.Id).NotEmpty();
            this.RuleFor(entity => entity.Name).NotEmpty();
        }
    }
}
