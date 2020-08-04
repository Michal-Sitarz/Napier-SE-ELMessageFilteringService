using ELMessageFilteringService.Models.Enums;

namespace ELMessageFilteringService.Models
{
    public abstract class Message
    {
        private string id;
        public string Id
        {
            get => id;
            set => id = value.Substring(0, 9); // Defensive measure - discard any overflowing characters.
        }

        public MessageType Type { get; set; }

        private string sender;
        public string Sender
        {
            get => sender;
            set => sender = IsValidSender(value) ? value : "Invalid sender";
        }

        public abstract string Content { get; set; }

        public abstract bool IsValidSender(string sender);

    }
}
