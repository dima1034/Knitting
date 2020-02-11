using System;
using Hangfire;
using Hangfire.SQLite;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Notification.Api.Infrastructure
{
    internal static class HangfireApplicationsBuilder
    {
        // public static void UseHangfire(this IApplicationBuilder app)
        // {
        //     var option = new BackgroundJobServerOptions
        //     {
        //         WorkerCount = GetWorkerCount(), ServerCheckInterval = new TimeSpan(0, 1, 0)
        //     };
        //
        //     app.UseHangfireServer();
        //     // app.UseHangfireDashboard();
        // }
        
        // public static void UseHangfire(
        //     this IGlobalConfiguration config, IMediator mediator)
        // {
        //     // config.UseActivator(new MediatorJobActivator(mediator));
        //
        //     config.UseSerializerSettings(new JsonSerializerSettings
        //     {
        //         TypeNameHandling = TypeNameHandling.Objects,
        //     });
        // }

        // public static void AddHangfire(
        //     this IServiceCollection services,
        //     IGlobalConfiguration globalConfiguration,
        //     IConfiguration configuration)
        // {
        //     globalConfiguration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //                        .UseSimpleAssemblyNameTypeSerializer()
        //                        .UseRecommendedSerializerSettings()
        //                         // .UseMemoryStorage(new MemoryStorageOptions { JobExpirationCheckInterval = TimeSpan.FromMinutes(10) })
        //                         // .UseSQLiteStorage("Filename=psm.db", sqliteOptions)
        //                        .UseSQLiteStorage(
        //                             configuration.GetConnectionString("HangfireSqliteConnection"),
        //                             new SQLiteStorageOptions());
        // }
        //
        // private static int GetWorkerCount() => Environment.ProcessorCount;
    }
}