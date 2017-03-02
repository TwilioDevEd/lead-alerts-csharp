using System.ComponentModel.DataAnnotations;

namespace LeadAlerts.Web.ViewModels
{
    public class Lead
    {
        public string HouseTitle { get; set; }
        [Display(Name = "Your Name")]
        public string Name { get; set; }
        [Display(Name = "Your Phone Number")]
        public string Phone { get; set; }
        [Display(Name = "How can we help?")]
        public string Message { get; set; }
    }
}