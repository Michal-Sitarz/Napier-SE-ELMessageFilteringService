using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ELMessageFilteringService.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IDataProvider _dataProvider;

        private StatisticsDTO stats = new StatisticsDTO();

        public StatisticsService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            StatisticsDTO statsFromFile = _dataProvider.ImportStatistics();
            if (statsFromFile != null)
            {
                stats = statsFromFile;
            }
        }

        public StatisticsDTO GetStatistics()
        {
            return stats;
        }

        public void UpdateStatistics()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };


            //var v = new { Amount = 108, Message = "Hello" };  
            //var stats = new { HashtagsOccurrence, MentionsOccurrence };


            var json = JsonSerializer.Serialize(stats, jsonOptions);
            //var hashtagsJson = JsonSerializer.Serialize(HashtagsOccurrence, jsonOptions);
            //var mentionsJson = JsonSerializer.Serialize(MentionsOccurrence, jsonOptions);
            //var registeredSIRsJson = JsonSerializer.Serialize(MentionsOccurrence, jsonOptions);
            //var quarantinedUrlsJson = JsonSerializer.Serialize(MentionsOccurrence, jsonOptions);

            _dataProvider.ExportStatistics(stats);

        }

        public void AddHashtags(IList<string> hashtags)
        {
            foreach (var h in hashtags)
            {
                if (!stats.HashtagsOccurrence.ContainsKey(h))
                {
                    stats.HashtagsOccurrence.Add(h, 1); // introduce a new hashtag
                }
                else
                {
                    stats.HashtagsOccurrence[h]++; // increase count of an existing hashtag
                }
            }
        }

        public void AddMentions(IList<string> mentions)
        {
            foreach (var m in mentions)
            {
                if (!stats.MentionsOccurrence.ContainsKey(m))
                {
                    stats.MentionsOccurrence.Add(m, 1); // introduce a new mention
                }
                else
                {
                    stats.MentionsOccurrence[m]++; // increase count of an existing mention
                }
            }
        }

        public void AddSIRs(string sportCentreCode, string natureOfIncident)
        {
            stats.SIRsRegistered.Add(sportCentreCode, natureOfIncident);
        }

        public void AddQuarantinedUrls(IList<string> urls)
        {
            foreach (var u in urls)
            {
                stats.QuarantinedUrls.Add(u);
            }
        }
    }
}
