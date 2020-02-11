using System.Threading.Tasks;
using NotificationService.Email;
using NUnit.Framework;

namespace NotificationService.EmailSender.UnitTests
{
    public class EmailSenderServiceTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public async Task Test1()
        {
            // await new EmailService().SendEmailAsync(
            //     "ostap.kernel@gmail.com",
            //     "test",
            //     "hello, it is test message from Dima");
            //
            await new Email.EmailNotificationService().SendEmailAsync(
                "dosta@softserveinc.com",
                "test",
                "hello, it is test message from Dima");

            Assert.Pass();
        }
    }
}