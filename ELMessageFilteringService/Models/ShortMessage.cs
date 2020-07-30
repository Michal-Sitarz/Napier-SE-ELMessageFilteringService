using System.Collections.Generic;

namespace ELMessageFilteringService.Models
{
    public abstract class ShortMessage : Message
    {
        public override string Content { get; set; } //TODO > must be max 140 characters

        //private readonly IDictionary<string, string> _abbreviations;

        //public ShortMessage(IDictionary<string,string> abbreviations)
        //{
        //    _abbreviations = abbreviations;
        //}

        public void SanitizeText(IDictionary<string,string> abbreviations)
        {

        }
    }
}
