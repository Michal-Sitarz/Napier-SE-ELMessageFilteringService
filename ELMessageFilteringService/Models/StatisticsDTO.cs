using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ELMessageFilteringService.Models
{
    public class StatisticsDTO
    {
        public IDictionary<string, int> HashtagsOccurrence { get; set; } = new Dictionary<string, int>();

        public IDictionary<string, int> MentionsOccurrence { get; set; } = new Dictionary<string, int>();

        public IList<SIRdetails> SIRsRegistered { get; set; } = new List<SIRdetails>();

        public IList<string> QuarantinedUrls { get; set; } = new List<string>();
    }
}
