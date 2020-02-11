using System;
using System.Threading.Tasks;
using MimeKit;

namespace NotificationService.Email.Builders
{
    public sealed class MimeKitSmtpClientBuilder : IDisposable
    {
        MailKit.Net.Smtp.SmtpClient _client;
        Task _connectTask;
        Task _authenticateTask;
        Task _sendTask;
        Task _disconnectTask;

        public MimeKitSmtpClientBuilder CreateSmtpClient()
        {
            _client = new MailKit.Net.Smtp.SmtpClient();

            return this;
        }

        public MimeKitSmtpClientBuilder SetUpConnection(string userName, string password)
        {
            _connectTask = _client.ConnectAsync("smtp.gmail.com", 587, false);
            _authenticateTask = _client.AuthenticateAsync(userName, password);

            return this;
        }

        public MimeKitSmtpClientBuilder Send(MimeMessage message)
        {
            _sendTask = _client.SendAsync(message);

            return this;
        }

        public MimeKitSmtpClientBuilder Disconnect()
        {
            _disconnectTask = _client.DisconnectAsync(true);

            return this;
        }
        
        public async Task BuildAsync()
        {
            await _connectTask.ConfigureAwait(true);
            await _authenticateTask.ConfigureAwait(true);
            await _sendTask.ConfigureAwait(true);
            await _disconnectTask.ConfigureAwait(true);
        }

        public void Dispose() { _client?.Dispose(); }
    }
}