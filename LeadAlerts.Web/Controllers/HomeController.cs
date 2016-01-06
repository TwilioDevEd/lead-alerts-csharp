using System.Web.Mvc;

namespace LeadAlerts.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "555 Sunnybrook Lane";
            ViewBag.Price = "$349,999";
            ViewBag.Description =
                "You and your family will love this charming home. " +
                "Featuring granite appliances, stainless steel windows, and " +
                "high efficiency dual mud rooms, this joint is loaded to the max. " +
                "Motivated sellers have priced for a quick sale, act now!";

            return View();
        }
    }
}