using System.Collections.Generic;

namespace ELMessageFilteringService.Models
{
    public abstract class ShortMessage : Message
    {
        private string content;
        public override string Content {
            get => content;
            set
            {
                if (value.Length > 140)
                {
                    content = value.Substring(0, 140); // Make sure Content has 140 characters max. Overflowing characters will be discarded.
                }
                else
                {
                    content = value;
                }
            }
        }

        public void SanitizeContent(IDictionary<string, string> abbreviations)
        {
            if(Content.Length > 0 && abbreviations != null)
            {
                string[] contentWords = Content.Split(' ');

                var keywords = abbreviations.Keys;

                for (int i = 0; i < contentWords.Length; i++)
                {
                    if (keywords.Contains(contentWords[i].ToUpper()))
                    {
                        contentWords[i] += " <" + abbreviations[contentWords[i]] + ">";
                    }
                }

                Content = string.Join(' ', contentWords);
            }
        }
    }
}
