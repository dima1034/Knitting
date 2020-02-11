using System;
using System.Net.Http;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace NotificationService.Api.UnitTests
{
    internal static class HttpClientCallInvokerFactory
    {
        // public static HttpClientCallInvoker Create(
        //     HttpClient httpClient,
        //     ILoggerFactory? loggerFactory = null,
        //     ISystemClock? systemClock = null,
        //     Action<GrpcChannelOptions>? configure = null,
        //     bool? disableClientDeadlineTimer = null)
        // {
        //     var channelOptions = new GrpcChannelOptions
        //     {
        //         LoggerFactory = loggerFactory,
        //         HttpClient    = httpClient
        //     };
        //     configure?.Invoke(channelOptions);
        //
        //     var channel = GrpcChannel.ForAddress(httpClient.BaseAddress, channelOptions);
        //     // channel.Clock = systemClock ?? SystemClock.Instance;
        //     if (disableClientDeadlineTimer != null)
        //     {
        //         // channel.DisableClientDeadlineTimer = disableClientDeadlineTimer.Value;
        //     }
        //
        //     return new HttpClientCallInvoker(channel);
        // }
    }
}