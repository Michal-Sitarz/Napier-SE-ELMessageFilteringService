using ELMessageFilteringService.Models;
using System.Collections.Generic;

namespace ELMessageFilteringService.Services
{
    public interface IStatisticsService
    {
        public StatisticsDTO GetStatistics();

        public void UpdateStatistics();

        public void AddHashtags(IList<string> hashtags);

        public void AddMentions(IList<string> mention);

        public void AddSIRs(string sportCentreCode, string natureOfIncident);

        public void AddQuarantinedUrls(IList<string> urls);
    }
}
