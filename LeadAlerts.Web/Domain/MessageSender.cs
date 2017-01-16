using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace LeadAlerts.Web.Domain
{
    public interface IMessageSender
    {
        Task<MessageResource> SendAsync(string messageStr); 
    }

    public class MessageSender: IMessageSender
    {
        public MessageSender() {
            TwilioClient.Init(Credentials.AccountSID, Credentials.AuthToken);
        }

        public async Task<MessageResource> SendAsync(string messageStr)
        {
            return await MessageResource.CreateAsync(
                new PhoneNumber(PhoneNumbers.Twilio),
                from: new PhoneNumber(PhoneNumbers.Agent),
                body: messageStr
            );
        }
    }
}
