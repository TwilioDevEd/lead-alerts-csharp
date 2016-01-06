using LeadAlerts.Web.Controllers;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LeadAlerts.Web.Tests.Controllers
{
    public class NotificationsControllerTest
    {
        [Test]
        public void GivenACreateAction_ThenItSendsAMessage()
        {
            var mockMessageSender = new Mock<IMessageSender>();
            var controller = new NotificationsController(mockMessageSender.Object);

            controller.WithCallTo(c => c.Create(new Lead()))
                .ShouldRedirectTo<HomeController>(home => home.Index());

            mockMessageSender.Verify(c => c.Send(It.IsAny<string>()), Times.Once);
        }
    }
}
