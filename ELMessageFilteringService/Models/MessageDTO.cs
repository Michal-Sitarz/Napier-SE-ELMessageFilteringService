using ELMessageFilteringService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Models
{
    public class MessageDTO
    {
        public string Header { get; set; }
        public string Body { get; set; }

        public bool HasValidHeader()
        {
            if (Header.Length == 10)
            {
                char messageTypeIndicator = Header[0];
                if (Enum.IsDefined(typeof(MessageType), messageTypeIndicator) 
                    && int.TryParse(Header.Substring(1), out _)) 
                    return true;
            }
            return false;
        }
    }
}
