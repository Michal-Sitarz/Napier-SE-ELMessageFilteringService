using System.Collections.Generic;

namespace ELMessageFilteringService.Models
{
    public abstract class ShortMessage : Message
    {
        public override string Content { get; set; } //TODO > must be max 140 characters

        public void SanitizeText(IDictionary<string, string> abbreviations)
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
