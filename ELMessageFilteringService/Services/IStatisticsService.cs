using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Services
{
    public interface IStatisticsService
    {
        //public void LoadStatistics();

        //public void UpdateStatistics();

        public void AddHashtags(IList<string> hashtags);

        public void AddMentions(IList<string> mention);

        public void AddQuarantinedUrls(IList<string> urls);

        public void AddSIRs(string sportCentreCode, string natureOfIncident);
    }
}
