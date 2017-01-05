using System.Web.Configuration;

namespace LeadAlerts.Web.Domain
{
    public class Credentials
    {
        public static string AccountSID
        {
            get { return WebConfigurationManager.AppSettings["TwilioAccountSid"] ??
                    "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"; }
        }

        public static string AuthToken
        {
            get { return WebConfigurationManager.AppSettings["TwilioAuthToken"] ?? 
                    "aXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"; }
        }
    }


    public class PhoneNumbers
    {
        public static string Twilio
        {
            get { return WebConfigurationManager.AppSettings["TwilioPhoneNumber"]; }
        }

        public static string Agent
        {
            get { return WebConfigurationManager.AppSettings["AgentPhoneNumber"]; }
        }
    }
}