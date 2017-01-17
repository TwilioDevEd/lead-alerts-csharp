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
            var to = new PhoneNumber(PhoneNumbers.Twilio);
            return await MessageResource.CreateAsync(
                to,
                from: new PhoneNumber(PhoneNumbers.Agent),
                body: message,
                client: _client
            );
        }
    }
}
