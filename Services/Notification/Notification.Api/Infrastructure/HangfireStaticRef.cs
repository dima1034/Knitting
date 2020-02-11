using MediatR;

namespace Notification.Api.Infrastructure
{
    public class HangfireStaticRef
    {
        public static IMediator Mediator { private get; set; }

        public static void Send(IRequest command)
        {
            Mediator.Send(command);
        }
    }
}