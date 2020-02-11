using NUnit.Framework;
using Grpc.AspNetCore.Server.Internal;
using Grpc.Core;
using Grpc.Net.Client.Web;
using NotificationService.Email;
using NotificationService.Api.Communication.Services;

namespace NotificationService.Api.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Test1()
        {
            new GreeterService(null, new EmailNotificationService()).SayHello(null, null);
            Assert.Pass();
        }
    }
}