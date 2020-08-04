using ELMessageFilteringService.Models;
using ELMessageFilteringService.Services;
using System.Collections.Generic;

namespace ELMessageFilteringService.ViewModels
{
    public class DisplayStatisticsViewModel : BaseViewModel
    {
        private readonly IStatisticsService _statisticsService;

        #region UI Binding Fields
        public string HashtagsTextBlock { get; private set; }
        public string MentionsTextBlock { get; private set; }
        public string SIRsTextBlock { get; private set; }
        public string UrlsTextBlock { get; private set; }

        public IDictionary<string,int> HashtagsCollection { get; private set; }
        public IDictionary<string,int> MentionsCollection { get; private set; }
        public IList<SIRdetails> SIRsCollection { get; private set; }
        public IList<string> UrlsCollection { get; private set; }

        #endregion

        #region Constructor
        public DisplayStatisticsViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;

            HashtagsTextBlock = "Hashtags Occurrence";
            MentionsTextBlock = "Mentions Occurrence";
            SIRsTextBlock = "Significant Incident Reports";
            UrlsTextBlock = "Quarantined Urls";

            LoadStatistics();
        }
        #endregion

        #region Other Helper Methods
        private void LoadStatistics()
        {
            var stats = _statisticsService.GetStatistics();
            
            HashtagsCollection = stats.HashtagsOccurrence;
            MentionsCollection = stats.MentionsOccurrence;
            SIRsCollection = stats.SIRsRegistered;
            UrlsCollection = stats.QuarantinedUrls;
        }
        #endregion
    }
}
