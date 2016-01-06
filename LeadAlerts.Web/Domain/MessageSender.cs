using Twilio;

namespace LeadAlerts.Web.Domain
{
    public interface IMessageSender
    {
        Message Send(string message);
    }

    public class MessageSender : IMessageSender
    {
        private readonly TwilioRestClient _client;

        public MessageSender() : this(
            new TwilioRestClient(Credentials.AccountSID, Credentials.AuthToken)) { }


        public MessageSender(TwilioRestClient client)
        {
            _client = client;
        }

        public Message Send(string message)
        {
            return _client.SendMessage(PhoneNumbers.Twilio, PhoneNumbers.Agent, message);
        }
    }
}