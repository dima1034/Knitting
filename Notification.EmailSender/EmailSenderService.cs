using System;
using System.Net.Mail;
using System.Threading.Tasks;
using NotificationService.Email.Builders;

namespace NotificationService.Email
{
    public class EmailSenderService
    {
        public EmailSenderService()
        {
            Console.WriteLine('s');
        }
        
        // private readonly Domain.IKeyValueProvider _keyValue;
        // public EmailSenderService(Domain.IKeyValueProvider keyValue) { _keyValue = keyValue; }
        
        public async Task SendEmailAsync(string receiverEmail, string subject, string message)
        {
            // var senderEmail         = await _keyValue.GetValue("EmailHost");
            // var senderEmailPassword = await _keyValue.GetValue("EmailPassword");
            //
            // var mail = new MailMessageBuilder().CreateNewMimeMessage(MailPriority.High)
            //                                     .CreateSender(senderEmail)
            //                                     .SetBody(message)
            //                                     .SetSubject(subject)
            //                                     .CreateReceiver(receiverEmail)
            //                                     .Get();
            //
            // await new SmtpClientBuilder().SetUpConnection(senderEmail, senderEmailPassword)
            //                              .Send(mail)
            //                              .BuildAsync();
        }
    }
}