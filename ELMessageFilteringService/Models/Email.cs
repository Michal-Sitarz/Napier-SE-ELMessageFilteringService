using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public class Email : Message
    {
        private string content;
        public override string Content
        {
            get => content;
            set
            {
                if(value.Length > 1028)
                {
                    content = value.Substring(0, 1028); // Make sure Content has 1028 characters max. Overflowing characters will be discarded.
                }
                else
                {
                    content = value;
                }
            }
        }

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

        public void SetSubjectContentAndSIRflag()
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
                var subject = Content.Substring(0, 20);
                var content = Content.Substring(20);
                
                Subject = subject.TrimEnd();
                Content = content;

                if (Subject.StartsWith("SIR"))
                {
                    IsSIR = true;
                }
            }
        }

        public IList<string> SterilizeContentFromUrls()
        {
            var quarantinedUrls = new List<string>();
            if (Content.Length > 0)
            {
                string[] contentWords = Content.Split(' ');

                for (int i = 0; i < contentWords.Length; i++)
                {
                    if (contentWords[i].StartsWith("http://")
                        || contentWords[i].StartsWith("https://"))
                    {
                        quarantinedUrls.Add(contentWords[i]);
                        contentWords[i] = "<URL Quarantined>";
                    }
                }

                Content = string.Join(' ', contentWords);
            }
            return quarantinedUrls;
        }
    }
}
