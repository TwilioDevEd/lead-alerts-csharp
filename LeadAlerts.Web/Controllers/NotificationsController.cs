using System.Web.Mvc;
using LeadAlerts.Web.Domain;
using LeadAlerts.Web.ViewModels;
using Vereyon.Web;
using System.Threading.Tasks;

namespace LeadAlerts.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationsController() : this(new NotificationService()) { }

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // POST: Notifications/Create
        [HttpPost]
        public async Task<ActionResult> Create(Lead lead)
        {
            var message = await _notificationService.SendAsync(FormatMessage(lead));

            if (message.ErrorCode.HasValue)
            {
                FlashMessage.Danger("Oops! There was an error. Please try again.");
            }
            else
            {
                FlashMessage.Confirmation("Thanks! An agent will be contacting you shortly.");
            }

            return RedirectToAction("Index", "Home");
        }

        private static string FormatMessage(Lead lead)
        {
            return $"New lead received for {lead.HouseTitle}. Call {lead.Name} at {lead.Phone}. Message: {lead.Message}";
        }
    }
}