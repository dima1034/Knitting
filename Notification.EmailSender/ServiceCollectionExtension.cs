using Microsoft.Extensions.DependencyInjection;

namespace NotificationService.Email
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEmailSenderService(this IServiceCollection services)
        {
            services.AddTransient<EmailSenderService>();
            return services;
        }
    }
}