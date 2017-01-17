using System.Web.Configuration;

namespace LeadAlerts.Web.Domain
{
    public class Credentials
    {
        public static string AccountSID => WebConfigurationManager.AppSettings["TwilioAccountSid"];

        public static string AuthToken => WebConfigurationManager.AppSettings["TwilioAuthToken"];
    }


    public class PhoneNumbers
    {
        public static string Twilio => WebConfigurationManager.AppSettings["TwilioPhoneNumber"];

        public static string Agent => WebConfigurationManager.AppSettings["AgentPhoneNumber"];
    }
}