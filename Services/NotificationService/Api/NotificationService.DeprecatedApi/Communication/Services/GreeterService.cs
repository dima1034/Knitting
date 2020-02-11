using System.Threading.Tasks;
using Grpc.Core;
using Hangfire;
using Microsoft.Extensions.Logging;
using NotificationService.DeprecatedApi.Notifications.Commands;
using NotificationService.Email;
using NotificationService.GrpcService.Communication.Services;

namespace NotificationService.DeprecatedApi.Communication.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService>  _logger;
        private readonly EmailNotificationService _service;

        public GreeterService(ILogger<GreeterService> logger, EmailNotificationService service)
        {
            _logger  = logger;
            _service = service;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var id = BackgroundJob.Enqueue(
                () =>
                    new QueueEmailEventCommand(
                        _service,
                        "dosta@softserveinc.com",
                        "test",
                        "hello, it is test message from Dima").Execute(null));

            return await Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }
}