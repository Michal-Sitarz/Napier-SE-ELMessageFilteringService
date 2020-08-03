using ELMessageFilteringService.Models;
using System.Collections.Generic;

namespace ELMessageFilteringService.DataAccess
{
    public interface IDataProvider
    {
        public bool ExportMessage(object message);

        public IList<RawMessage> ImportMessages();

        public IDictionary<string, string> ImportAbbreviations();

    }
}
