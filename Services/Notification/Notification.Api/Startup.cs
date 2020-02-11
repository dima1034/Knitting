using System;
using Hangfire;
using Hangfire.SQLite;
using InfrastructureContracts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notification.Api.Infrastructure;
using Notification.KeyVault;
using NotificationService.Email;

namespace Notification.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(cfg => cfg.AsSingleton(), typeof(Startup).Assembly, typeof(EmailSenderService).Assembly);
            services.AddHangfire(
                configuration => configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                              .UseSimpleAssemblyNameTypeSerializer()
                                              .UseRecommendedSerializerSettings()
                                               // .UseMemoryStorage(new MemoryStorageOptions { JobExpirationCheckInterval = TimeSpan.FromMinutes(10) })
                                               // .UseSQLiteStorage("Filename=psm.db", sqliteOptions)
                                              .UseSQLiteStorage(
                                                   Configuration.GetConnectionString("HangfireSqliteConnection"),
                                                   new SQLiteStorageOptions()));

            services.AddSingleton<IKeyValueProvider, AzureKeyVaultProvider>();
            services.AddSingleton(
                (serviceProvider) =>
                {
                    IKeyValueProvider keyVault = serviceProvider.GetService<IKeyValueProvider>();
                    return new EmailSenderService(keyVault);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // app.UseHangfire();
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}