using LeadAlerts.Web.Domain;
using NUnit.Framework;
using Twilio;
using Twilio.Http;
using Twilio.Clients;
using Moq;
using System.Threading.Tasks;

namespace LeadAlerts.Web.Tests.Domain
{
    public class MessageSenderTest
    {
        [Test]
        public void MessageSender_SendsAMessage()
        {
            var twilioClientMock = new Mock<ITwilioRestClient>();
            twilioClientMock.Setup(c => c.AccountSid).Returns("AccountSID");
            twilioClientMock.Setup(c => c.RequestAsync(It.IsAny<Request>()))
                              .ReturnsAsync(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"messaging_service_sid\": \"MGaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var messageSender = new MessageSender();

            TwilioClient.SetRestClient(twilioClientMock.Object);

            Task.Run(async () =>
            {
                await messageSender.SendAsync("message");
                twilioClientMock.Verify(
                c => c.RequestAsync(It.IsAny<Request>()), Times.Once);
            }).GetAwaiter().GetResult();
        }
    }
}
