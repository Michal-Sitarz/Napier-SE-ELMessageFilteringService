using ELMessageFilteringService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Models
{
    public class MessageDTO
    {
        //private string header;
        //public string Header { get => header; set => value.ToUpper(); }
        public string Header { get; set; }
        public string Body { get; set; }

        public bool IsValid()
        {
            if (Body.Length > 0 && Header.Length == 10)
            {
                char messageTypeIndicator = Header[0];
                //var messageTypeIndicator = "Sms";
                // cast int for a char-based enum, as the char is not a valid enum value type
                if (Enum.IsDefined(typeof(MessageType), (int)messageTypeIndicator)
                    && int.TryParse(Header.Substring(1), out _))
                    return true;
                //if (Enum.TryParse(messageTypeIndicator, out MessageType _) && int.TryParse(Header.Substring(1), out _))
                //{
                //    return true;
                //}
            }
            return false;
        }
    }
}
