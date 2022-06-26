namespace PaymentGateway.Presentation.Configuration
{
    using Infrastructure.CrossCutting.Interfaces;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using PaymentGateway.Domain.Core.Interfaces;
    using PaymentGateway.Gateway.AcquiringBank;
    using PaymentGateway.Gateway.AcquiringBank.Interfaces;
    using Refit;

    public static class AcquiringBankConfiguration
    {
        public static IServiceCollection AddAcquiringBank(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var settings = provider.GetRequiredService<IAcquiringBankSettings>();

            services.AddRefitClient<IAcquiringBankApi>(new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            })
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(settings.BaseUrl));

            services.AddSingleton<IAcquiringBankService, AcquiringBankService>();

            return services;
        }
    }
}
