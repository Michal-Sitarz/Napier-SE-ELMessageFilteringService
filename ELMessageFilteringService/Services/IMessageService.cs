using ELMessageFilteringService.Models;
using System.Collections.Generic;

namespace ELMessageFilteringService.Services
{
    public interface IMessageService
    {
        public Message AddNewMessage(RawMessage message);

        public IList<Message> GetExistingMessages();

        //public IDictionary<string, string> GetAbbreviations();
    }
}
