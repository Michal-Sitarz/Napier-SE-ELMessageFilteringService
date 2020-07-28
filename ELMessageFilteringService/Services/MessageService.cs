using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Services
{
    public class MessageService : IMessageService
    {
        public Message TranslateMessage(MessageDTO message)
        {
            if (message.HasValidHeader())
            {
                return new Email();
            }
            else
            {
                return null;
            }
        }

    }
}
