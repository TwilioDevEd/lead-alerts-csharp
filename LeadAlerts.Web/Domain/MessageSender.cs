using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using Twilio.Clients;

namespace LeadAlerts.Web.Domain
{
    public interface IMessageSender
    {
        Task<MessageResource> SendAsync(string message);
    }

    public class MessageSender: IMessageSender
    {
        private readonly TwilioRestClient _twilioRestClient;

        public MessageSender() {
            _twilioRestClient = new TwilioRestClient(Credentials.AccountSID, Credentials.AuthToken);
        }

        public async Task<MessageResource> SendAsync(string message)
        {
            return await MessageResource.CreateAsync(
                new PhoneNumber(PhoneNumbers.Twilio),
                from: new PhoneNumber(PhoneNumbers.Agent),
                body: message,
                client: _twilioRestClient
            );
        }
    }
}
