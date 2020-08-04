using ELMessageFilteringService.Models.Enums;
using System;

namespace ELMessageFilteringService.Models
{
    public class RawMessage
    {
        private string header;
        public string Header { get => header; set => header = value.ToUpper(); }

        public string Body { get; set; }

        public bool IsValid()
        {
            if (Body.Length > 0 && Header.Length == 10)
            {
                char messageTypeIndicator = Header[0];

                if (Enum.IsDefined(typeof(MessageType), (int)messageTypeIndicator) // cast int, as Enum holds "numeric" values
                    && int.TryParse(Header.Substring(1), out _))
                    return true;
            }
            return false;
        }
    }
}
