using ELMessageFilteringService.Models;
using System.Collections.Generic;

namespace ELMessageFilteringService.DataAccess
{
    public interface IDataProvider
    {
        public bool ExportMessage(object message);

        //public Message ImportLastMessage();

        public IList<RawMessage> ImportRawMessages();

        public IDictionary<string, string> ImportAbbreviations();

        public StatisticsDTO ImportStatistics();

        public bool ExportStatistics(StatisticsDTO statistics);

    }
}
