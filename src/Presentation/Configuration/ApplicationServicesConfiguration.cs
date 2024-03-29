﻿namespace PaymentGateway.Presentation.Configuration
{
    using PaymentGateway.Application.Services;
    using PaymentGateway.Application.Services.Interfaces;

    public static class ApplicationServicesConfiguration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IPaymentApplicationService, PaymentApplicationService>();
            return services;
        }
    }
}
