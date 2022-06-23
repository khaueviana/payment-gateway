namespace PaymentGateway.Presentation.Configuration
{
    using FluentValidation;
    using PaymentGateway.Presentation.Dto.Payments;
    using PaymentGateway.Presentation.Validators.Payments;

    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<PaymentRequest>, PaymentRequestValidator>();

            return services;
        }
    }
}
