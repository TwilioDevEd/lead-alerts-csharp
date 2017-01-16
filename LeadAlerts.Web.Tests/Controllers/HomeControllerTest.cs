using LeadAlerts.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LeadAlerts.Web.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Test]
        public void GivenAIndexAction_ThenRendersDefaultView()
        {
            var controller = new HomeController();

            controller.WithCallTo(c => c.Index())
                .ShouldRenderView("Index");
        }
    }
}
