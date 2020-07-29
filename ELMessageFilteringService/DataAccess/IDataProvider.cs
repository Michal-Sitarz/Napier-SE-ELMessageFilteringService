using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.DataAccess
{
    public interface IDataProvider
    {
        public bool ExportMessage(Message message);

        public IList<MessageDTO> ImportMessages();

        public IDictionary<string, string> ImportAbbreviations();

    }
}
