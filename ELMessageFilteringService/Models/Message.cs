using ELMessageFilteringService.Models.Enums;
using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public abstract class Message
    {
        public char[] Id { get; set; } = new char[10];
        public MessageType Type { get; set; }
        public abstract string Sender { get; set; }
        public abstract string Content { get; set; }
    }
}
