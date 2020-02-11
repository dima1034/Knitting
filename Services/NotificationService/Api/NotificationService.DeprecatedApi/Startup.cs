using Hangfire;
using Hangfire.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationService.DeprecatedApi.Communication.Services;
using NotificationService.Email;

namespace NotificationService.DeprecatedApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(
                configuration => configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                              .UseSimpleAssemblyNameTypeSerializer()
                                              .UseRecommendedSerializerSettings()
                                               // .UseMemoryStorage(new MemoryStorageOptions { JobExpirationCheckInterval = TimeSpan.FromMinutes(10) })
                                               // .UseSQLiteStorage("Filename=psm.db", sqliteOptions)
                                              .UseSQLiteStorage(
                                                   Configuration.GetConnectionString("HangfireSqliteConnection"),
                                                   new SQLiteStorageOptions()));

            services.AddGrpc();
            services.AddHangfireServer();
            services.AddSingleton<EmailNotificationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
            //                                         .AddJsonFile(
            //                                              "appsettings.json",
            //                                              optional: false,
            //                                              reloadOnChange: true)
            //                                         .AddJsonFile(
            //                                              $"appsettings.{env.EnvironmentName}.json",
            //                                              optional: true)
            //                                         .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfire();
            app.UseRouting();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapGrpcService<GreeterService>();

                    endpoints.MapGet(
                        "/",
                        async context =>
                        {
                            await context.Response.WriteAsync(
                                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                        });
                });
        }
    }
}