using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;

namespace ELMessageFilteringService.DataAccess
{
    public class DataProvider : IDataProvider
    {
        public bool ExportMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public IList<MessageDTO> ImportMessages()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> ImportAbbreviations()
        {
            throw new NotImplementedException();
        }
    }
}
