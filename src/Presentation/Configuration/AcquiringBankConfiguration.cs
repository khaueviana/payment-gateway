namespace PaymentGateway.Presentation.Configuration
{
    using Infrastructure.CrossCutting.Interfaces;
    using PaymentGateway.Gateway.AcquiringBank.Interfaces;
    using Refit;

    public static class AcquiringBankConfiguration
    {
        public static IServiceCollection AddAcquiringBank(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var settings = provider.GetRequiredService<IAcquiringBankSettings>();

            services
            .AddRefitClient<IAcquiringBankApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(settings.BaseUrl));

            return services;
        }
    }
}
