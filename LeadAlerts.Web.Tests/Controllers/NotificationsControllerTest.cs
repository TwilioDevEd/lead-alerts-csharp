using System.Web;
using LeadAlerts.Web.Controllers;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using Twilio;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;

namespace LeadAlerts.Web.Tests.Controllers
{
    public class NotificationsControllerTest
    {
        [Test]
        public void GivenACreateAction_ThenItSendsAMessage()
        {
            HttpContext.Current = new HttpContext(
                new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));

            var messageSenderMock = new Mock<IMessageSender>();

            messageSenderMock.Setup(m => m.SendAsync(It.IsAny<string>()))
                .ReturnsAsync(MessageResource.FromJson("{}"));

            var controller = new NotificationsController(messageSenderMock.Object);

            controller.WithCallTo(c => c.Create(new Lead()))
                .ShouldRedirectToRoute("");

            messageSenderMock.Verify(
                c => c.SendAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
