using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using Twilio.Clients;

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
            return await MessageResource.CreateAsync(
                to: new PhoneNumber(PhoneNumbers.Agent),
                from: new PhoneNumber(PhoneNumbers.Twilio),
                body: message,
                client: _client
            );
        }
    }
}
