using System;
using System.Windows.Input;
using NotificationService.Email;

namespace NotificationService.Api.Notifications.Commands
{
    public class QueueEmailEventCommand : ICommand
    {
        private readonly EmailNotificationService _service;
        private readonly string                   _receiverEmail;
        private readonly string                   _subject;
        private readonly string                   _message;

        public QueueEmailEventCommand(
            EmailNotificationService service,
            string receiverEmail,
            string subject,
            string message)
        {
            _receiverEmail = receiverEmail;
            _subject       = subject;
            _message       = message;
            _service       = service;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _service.SendEmailAsync(_receiverEmail, _subject, _message);

        public event EventHandler CanExecuteChanged;
    }
}