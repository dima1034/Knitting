using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace Notification.Api.Infrastructure
{
    internal static class HangfireApplicationsBuilder
    {
        public static void UseHangfire(this IApplicationBuilder app)
        {
            var option = new BackgroundJobServerOptions
            {
                WorkerCount = GetWorkerCount(),
                ServerCheckInterval = new TimeSpan(0, 1, 0)
            };
            
            app.UseHangfireServer(option); 
            app.UseHangfireDashboard();
        }
        
        private static int GetWorkerCount() => Environment.ProcessorCount;
    }
}