using System.Collections.Generic;

namespace ELMessageFilteringService.Models
{
    public class Tweet : ShortMessage
    {
        public IList<string> Mentions { get; set; } = new List<string>();
        
        public IList<string> Hashtags { get; set; } = new List<string>();

        public override bool IsValidSender(string sender)
        {
            return sender.StartsWith('@')
                && sender.Substring(1).Length <= 15;
        }

        public void CheckContentForHashtagsAndMentions()
        {
            if(Content.Length > 0)
            {
                string[] contentWords = Content.Split(' ');
                foreach (var word in contentWords)
                {
                    if (word.StartsWith('#'))
                    {
                        Hashtags.Add(word);
                    }
                    if (word.StartsWith('@'))
                    {
                        Mentions.Add(word);
                    }
                }
            }
        }
    }
}
