using System.Net.Mail;
using MimeKit;

namespace NotificationService.Email.Builders
{
    public sealed class EmailMessageBuilder
    {
        private MailMessage Mail { get; set; }

        public EmailMessageBuilder CreateNewMimeMessage(MailPriority mailPriority)
        {
            Mail = new MailMessage { IsBodyHtml = true, Priority = mailPriority };
            return this;
        }

        public EmailMessageBuilder CreateSender(string email)
        {
            Mail.From = new MailAddress(email);

            return this;
        }

        public EmailMessageBuilder CreateReceiver(string email)
        {
            Mail.To.Add(new MailAddress(email));

            return this;
        }

        public EmailMessageBuilder SetSubject(string subject)
        {
            Mail.Subject = subject;

            return this;
        }

        public EmailMessageBuilder SetBody(string body)
        {
            Mail.Body = body;

            return this;
        }

        public MailMessage Get() => Mail;
    }
}