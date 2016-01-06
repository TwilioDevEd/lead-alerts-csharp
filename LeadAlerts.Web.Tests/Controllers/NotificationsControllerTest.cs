using System.Web;
using LeadAlerts.Web.Controllers;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using Twilio;

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

            var mockMessageSender = new Mock<IMessageSender>();
            mockMessageSender.Setup(ms => ms.Send(It.IsAny<string>())).Returns(new Message());
            var controller = new NotificationsController(mockMessageSender.Object);

            controller.WithCallTo(c => c.Create(new Lead()))
                .ShouldRedirectTo<HomeController>(home => home.Index());

            mockMessageSender.Verify(c => c.Send(It.IsAny<string>()), Times.Once);
        }
    }
}
