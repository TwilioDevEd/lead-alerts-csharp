using System.Web;
using LeadAlerts.Web.Controllers;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using Twilio.Rest.Api.V2010.Account;

namespace LeadAlerts.Web.Tests.Controllers
{
    public class NotificationsControllerTest
    {
        [Test]
        public void GivenACreateAction_ThenItSendsAMessage()
        {
            var messageSenderMock = new Mock<IMessageSender>();

            messageSenderMock.Setup(m => m.SendAsync(It.IsAny<string>()))
                .ReturnsAsync(MessageResource.FromJson("{}"));

            HttpContext.Current = new HttpContext(
                new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));
            var controller = new NotificationsController(messageSenderMock.Object);

            controller
                .WithCallTo(c => c.Create(new Lead()))
                .ShouldRedirectTo<HomeController>(c => c.Index());

            messageSenderMock.Verify(c => c.SendAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
