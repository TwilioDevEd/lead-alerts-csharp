using System.Web.Mvc;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Vereyon.Web;
using System.Threading.Tasks;

namespace LeadAlerts.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IMessageSender _messageSender;

        public NotificationsController() : this(new MessageSender()) { }

        public NotificationsController(IMessageSender messageSender)
        {
            _messageSender = messageSender;
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
            return $"New lead received for {lead.HouseTitle}. Call {lead.Name} at {lead.Phone}. Message: {lead.Message}";
        }
    }
}