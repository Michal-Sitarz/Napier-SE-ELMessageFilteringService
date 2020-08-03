using ELMessageFilteringService.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Services
{
    public class StatisticsService : IStatisticsService
    {
        //private readonly IDataProvider _dataProvider;

        public IDictionary<string, int> HashtagsOccurrence { get; private set; } = new Dictionary<string, int>();

        public IDictionary<string, int> MentionsOccurrence { get; private set; } = new Dictionary<string, int>();

        public IDictionary<string, string> SIRsRegistered { get; private set; } = new Dictionary<string, string>();

        public IList<string> QuarantinedUrls { get; private set; } = new List<string>();

        //public StatisticsService(/*IDataProvider dataProvider*/)
        //{
        //    //_dataProvider = dataProvider;
        //}

        //public void LoadStatistics()
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateStatistics()
        //{
        //    throw new NotImplementedException();
        //}

        public void AddHashtags(IList<string> hashtags)
        {
            foreach (var h in hashtags)
            {
                if (!HashtagsOccurrence.ContainsKey(h))
                {
                    HashtagsOccurrence.Add(h, 1); // introduce a new hashtag
                }
                else
                {
                    HashtagsOccurrence[h]++; // increase count of an existing hashtag
                }
            }
        }

        public void AddMentions(IList<string> mentions)
        {
            foreach (var m in mentions)
            {
                if (!MentionsOccurrence.ContainsKey(m))
                {
                    MentionsOccurrence.Add(m, 1); // introduce a new mention
                }
                else
                {
                    MentionsOccurrence[m]++; // increase count of an existing mention
                }
            }
        }

        public void AddSIRs(string sportCentreCode, string natureOfIncident)
        {
                SIRsRegistered.Add(sportCentreCode, natureOfIncident);
        }

        public void AddQuarantinedUrls(IList<string> urls)
        {
            foreach (var u in urls)
            {
                QuarantinedUrls.Add(u);
            }
        }
    }
}
