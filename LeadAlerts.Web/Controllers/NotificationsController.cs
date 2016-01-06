using System.Web.Mvc;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;

namespace LeadAlerts.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IMessageSender _messageSender;

        public NotificationsController() : this(
            new MessageSender()) { }

        public NotificationsController(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        // POST: Notifications/Create
        [HttpPost]
        public ActionResult Create(Lead lead)
        {
            _messageSender.Send(FormatMessage(lead));

            return RedirectToAction("Index", "Home");
        }

        private static string FormatMessage(Lead lead)
        {
            return string.Format(
                "New lead received for {0}. Call {1} at {2}. Message: {3}",
                lead.HouseTitle, lead.Name, lead.Phone, lead.Message);
        }
    }
}