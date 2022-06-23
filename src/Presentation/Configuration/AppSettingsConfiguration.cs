namespace PaymentGateway.Presentation.Configuration
{
    using Infrastructure.CrossCutting.Interfaces;
    using Infrastructure.CrossCutting.Settings;
    using Microsoft.Extensions.Options;

    public static class AppSettingsConfiguration
    {
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));
            services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

            services.Configure<AcquiringBankSettings>(configuration.GetSection("AcquiringBank"));
            services.AddSingleton<IAcquiringBankSettings>(sp => sp.GetRequiredService<IOptions<AcquiringBankSettings>>().Value);
        }
    }
}
