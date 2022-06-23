namespace PaymentGateway.Presentation.Configuration
{
    using Infrastructure.CrossCutting.Interfaces;
    using MongoDB.Driver;
    using PaymentGateway.Data.MongoDB.Repositories;
    using PaymentGateway.Domain.Core.Interfaces;

    public static class MongoDBConfiguration
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var settings = provider.GetRequiredService<IMongoDBSettings>();
                var client = new MongoClient(settings.ConnectionString);
                var databaseName = new MongoUrl(settings.ConnectionString).DatabaseName;
                return client.GetDatabase(databaseName);
            });

            services.AddSingleton<IPaymentsRepository, PaymentsRepository>();

            return services;
        }
    }
}
