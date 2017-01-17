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
            var notificationServiceMock = new Mock<INotificationService>();

            notificationServiceMock
                .Setup(m => m.SendAsync(It.IsAny<string>()))
                .ReturnsAsync(MessageResource.FromJson("{}"));

            HttpContext.Current = new HttpContext(
                new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));
            var controller = new NotificationsController(notificationServiceMock.Object);

            var lead = new Lead
            {
                HouseTitle = "La Maison",
                Name = "Alice",
                Phone = "555-5555",
                Message = "Welcome back!"
            };
            controller
                .WithCallTo(c => c.Create(lead))
                .ShouldRedirectTo<HomeController>(c => c.Index());


            const string message = "New lead received for La Maison. " +
                                   "Call Alice at 555-5555. Message: Welcome back!";
            notificationServiceMock.Verify(c => c.SendAsync(message), Times.Once);
        }
    }
}
