using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public class Email : Message
    {
        public override string Content { get; set; }

        public string Subject { get; private set; }

        public bool IsSIR { get; private set; }

        public override bool IsValidSender(string sender)
        {
            if (sender.Contains('@') && sender.IndexOf('@') == sender.LastIndexOf('@'))
            {
                var domain = sender.Substring(sender.IndexOf('@') + 1);
                Regex regex = new Regex(@"^[a-zA-Z0-9.]+$");
                if (regex.IsMatch(domain))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetSubjectContentSIRflag()
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
                var subject = Content.Substring(0, 20);
                var content = Content.Substring(21);
                
                Subject = subject;
                Content = content;

                if (Subject.StartsWith("SIR"))
                {
                    IsSIR = true;
                }
            }
        }

    }
}
