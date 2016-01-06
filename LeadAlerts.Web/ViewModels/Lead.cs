using System;
using System.ComponentModel.DataAnnotations;

namespace LeadAlerts.Web.ViewModels
{
    public class Lead
    {
        public String HouseTitle { get; set; }
        [Display(Name = "Your Name")]
        public String Name { get; set; }
        [Display(Name = "Your Phone Number")]
        public String Phone { get; set; }
        [Display(Name = "How can we help?")]
        public String Message { get; set; }
    }
}