using LeadAlerts.Web.Domain;
using Moq;
using NUnit.Framework;
using Twilio;

namespace LeadAlerts.Web.Tests.Domain
{
    public class MessageSenderTest
    {
        [Test]
        public void MessageSender_SendsAMessage()
        {
            var mockClient = new Mock<TwilioRestClient>(null, null);

            var messageSender = new MessageSender(mockClient.Object);
            messageSender.Send("message");

            mockClient.Verify(c => c.SendMessage(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
