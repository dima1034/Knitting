using System.Net.Mail;
using System.Threading.Tasks;
using NotificationService.Domain;
using NotificationService.Email.Builders;

namespace NotificationService.Email
{
    public class EmailSender
    {
        private readonly IKeyValueProvider _keyValue;
        public EmailSender(IKeyValueProvider keyValue) { _keyValue = keyValue; }
        
        public async Task SendEmailAsync(string receiverEmail, string subject, string message)
        {
            var senderEmail         = await _keyValue.GetValue("EmailHost");
            var senderEmailPassword = await _keyValue.GetValue("EmailPassword");

            var mail = new MailMessageBuilder().CreateNewMimeMessage(MailPriority.High)
                                                .CreateSender(senderEmail)
                                                .SetBody(message)
                                                .SetSubject(subject)
                                                .CreateReceiver(receiverEmail)
                                                .Get();

            await new SmtpClientBuilder().SetUpConnection(senderEmail, senderEmailPassword)
                                         .Send(mail)
                                         .BuildAsync();
        }
    }
}