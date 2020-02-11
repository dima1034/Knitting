using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NotificationService.Domain;
using NotificationService.Email.Builders;

namespace NotificationService.Email
{
    public class EmailNotificationService : INotificationService
    {
        private static readonly IConfigurationRoot BuiltConfig = new ConfigurationBuilder()
                                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                                .AddJsonFile(
                                                                     "appsettings.json",
                                                                     optional: false,
                                                                     reloadOnChange: true)
                                                                .Build();

        private static readonly IConfigurationSection KeyVaultSection = BuiltConfig.GetSection("KeyVault");

        private static readonly AzureKeyVault AzureKeyVault = new AzureKeyVault(
            KeyVaultSection["baseUri"],
            KeyVaultSection["appClientId"],
            KeyVaultSection["appClientSecret"]);

        public async Task SendEmailAsync(string receiverEmail, string subject, string message)
        {
            var senderEmail         = await AzureKeyVault.GetCachedSecret("EmailHost");
            var senderEmailPassword = await AzureKeyVault.GetCachedSecret("EmailPassword");

            var mail = new EmailMessageBuilder().CreateNewMimeMessage(MailPriority.High)
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