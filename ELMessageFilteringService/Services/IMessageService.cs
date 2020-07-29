using ELMessageFilteringService.Models;
using System.Collections.Generic;

namespace ELMessageFilteringService.Services
{
    public interface IMessageService
    {
        //public bool AddNewMessage(MessageDTO message);
        public Message AddNewMessage(MessageDTO message);
        public IList<Message> ImportMessages();

        //public bool ExportMessage(Message message);
    }
}
