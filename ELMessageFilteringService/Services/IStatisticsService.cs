using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Services
{
    public interface IStatisticsService
    {
        public StatisticsDTO GetStatistics();

        public void UpdateStatistics();

        public void AddHashtags(IList<string> hashtags);

        public void AddMentions(IList<string> mention);

        public void AddQuarantinedUrls(IList<string> urls);

        public void AddSIRs(string sportCentreCode, string natureOfIncident);
    }
}
