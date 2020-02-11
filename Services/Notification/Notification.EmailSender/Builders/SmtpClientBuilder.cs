using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MimeKit;

namespace NotificationService.Email.Builders
{
    public sealed class SmtpClientBuilder : IDisposable
    {
        SmtpClient _client;
        Task _sendTask;

        public SmtpClientBuilder SetUpConnection(string senderEmail, string senderEmailPassword)
        {
            _client = new SmtpClient
            {
                Port                  = 587,
                DeliveryMethod        = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host                  = "smtp.gmail.com",
                EnableSsl             = true,
                Credentials           = new NetworkCredential(senderEmail, senderEmailPassword)
            };

            return this;
        }

        public SmtpClientBuilder Send(System.Net.Mail.MailMessage message)
        {
            _sendTask = _client.SendMailAsync(message);

            return this;
        }

        public async Task BuildAsync() { await _sendTask; }

        public void Dispose() { _client?.Dispose(); }
    }
}