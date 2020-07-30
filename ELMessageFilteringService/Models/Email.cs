using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public class Email : Message
    {
        public override string Content { get; set; }
        //public override string Sender { get; set; }

        public string Subject { get; set; }
        public bool IsSIR { get; private set; }

        public override bool IsValidSender(string sender)
        {
            if (sender.Contains('@')) //&& sender.IndexOf('@') == sender.LastIndexOf('@')
            {
                var indexOfAt = sender.IndexOf('@');
                if (sender.LastIndexOf('@') == indexOfAt)
                {
                    var domain = sender.Substring(indexOfAt+1);
                    Regex regex = new Regex(@"^[a-zA-Z0-9.]+$");
                    if (regex.IsMatch(domain))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
