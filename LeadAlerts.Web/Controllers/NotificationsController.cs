using System.Web.Mvc;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Vereyon.Web;
using System.Threading.Tasks;

namespace LeadAlerts.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly MessageSender _messageSender;

        public NotificationsController() {
            _messageSender = new MessageSender();
        }
        
        // POST: Notifications/Create
        [HttpPost]
        public async Task<ActionResult> Create(Lead lead)
        {
            var message = await _messageSender.SendAsync(FormatMessage(lead));

            if (message.ErrorCode == null)
            {
                FlashMessage.Confirmation("Thanks! An agent will be contacting you shortly.");
            }
            else
            {
                FlashMessage.Danger("Oops! There was an error. Please try again.");
            }

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