using System.Net.Mail;
using MimeKit;

namespace NotificationService.Email.Builders
{
    public sealed class MailMessageBuilder
    {
        private System.Net.Mail.MailMessage Mail { get; set; }

        public MailMessageBuilder CreateNewMimeMessage(MailPriority mailPriority)
        {
            Mail = new System.Net.Mail.MailMessage { IsBodyHtml = true, Priority = mailPriority };
            return this;
        }

        public MailMessageBuilder CreateSender(string email)
        {
            Mail.From = new MailAddress(email);

            return this;
        }

        public MailMessageBuilder CreateReceiver(string email)
        {
            Mail.To.Add(new MailAddress(email));

            return this;
        }

        public MailMessageBuilder SetSubject(string subject)
        {
            Mail.Subject = subject;

            return this;
        }

        public MailMessageBuilder SetBody(string body)
        {
            Mail.Body = body;

            return this;
        }

        public System.Net.Mail.MailMessage Get() => Mail;
    }
}