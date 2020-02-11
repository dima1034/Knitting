using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Email;

namespace Notification.Api.Application.Commands
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly EmailSenderService _emailSenderService;

        public SendEmailCommandHandler() { }
        public SendEmailCommandHandler(EmailSenderService emailSenderService) { _emailSenderService = emailSenderService; }

        public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            await _emailSenderService.SendEmailAsync(request.ReceiverEmail, request.Subject, request.Message);

            return new Unit();
        }
    }
}