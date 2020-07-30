using ELMessageFilteringService.Models;
using System.Collections.Generic;

namespace ELMessageFilteringService.Services
{
    public interface IMessageService
    {
        public Message AddNewMessage(MessageDTO message);

        public IList<Message> GetExistingMessages();

        public IDictionary<string, string> GetAbbreviations();
    }
}
