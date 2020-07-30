using System.Collections.Generic;

namespace ELMessageFilteringService.Models
{
    public class Tweet : ShortMessage
    {
        public bool HasMentions { get; set; }
        public IList<string> Mentions { get; set; }
        
        public bool HasHashtags { get; set; }
        public IList<string> Hashtags { get; set; }

        public override bool IsValidSender(string sender)
        {
            return sender.StartsWith('@')
                && sender.Substring(1).Length <= 15;
        }
    }
}
