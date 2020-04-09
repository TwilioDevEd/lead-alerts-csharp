using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using Twilio.Clients;
using System.Net;

namespace LeadAlerts.Web.Domain
{
    public interface INotificationService
    {
        Task<MessageResource> SendAsync(string message);
    }

    public class NotificationService: INotificationService
    {
        private readonly TwilioRestClient _client;

        public NotificationService() {
            _client = new TwilioRestClient(Credentials.AccountSID, Credentials.AuthToken);
        }

        public async Task<MessageResource> SendAsync(string message)
        {
            var to = new PhoneNumber(PhoneNumbers.Agent);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12
                                                    | SecurityProtocolType.Ssl3;
            return await MessageResource.CreateAsync(
                to,
                from: new PhoneNumber(PhoneNumbers.Twilio),
                body: message,
                client: _client
            );
        }
    }
}
