using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Models
{
    public class StatisticsDTO
    {
        public IDictionary<string, int> HashtagsOccurrence { get; set; } = new Dictionary<string, int>();

        public IDictionary<string, int> MentionsOccurrence { get; set; } = new Dictionary<string, int>();

        public IDictionary<string, string> SIRsRegistered { get; set; } = new Dictionary<string, string>();

        public IList<string> QuarantinedUrls { get; set; } = new List<string>();
    }
}
