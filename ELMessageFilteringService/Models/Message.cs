using ELMessageFilteringService.Models.Enums;
using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public abstract class Message
    {
        //public char[] Id { get; set; } = new char[10];
        private string id;
        public string Id
        {
            get => id;
            set => id = value.Substring(0, 9);
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
