using System.Net.Mail;
using MimeKit;

namespace NotificationService.Email.Builders
{
    public sealed class MimeKitMessageBuilder
    {
        private MimeMessage Mail { get; set; }

        public MimeKitMessageBuilder CreateNewMimeMessage()
        {
            Mail = new MimeMessage();

            return this;
        }

        public MimeKitMessageBuilder CreateSender(string email)
        {
            Mail.From.Add(new MailboxAddress("", email));

            return this;
        }

        public MimeKitMessageBuilder CreateReceiver(string email)
        {
            Mail.To.Add(new MailboxAddress("", email));

            return this;
        }

        public MimeKitMessageBuilder SetSubject(string subject)
        {
            Mail.Subject = subject;

            return this;
        }

        public MimeKitMessageBuilder SetBody(string body)
        {
            Mail.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            return this;
        }

        public MimeMessage Get() => Mail;
    }
}