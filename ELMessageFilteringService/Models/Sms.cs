using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public class Sms : ShortMessage
    {
        public override bool IsValidSender(string sender)
        {
            var phoneNumber = sender.Substring(1);
            Regex regex = new Regex(@"^[0-9]+$"); // contains only digits

            return sender.StartsWith('+')
                && phoneNumber.Length <= 15
                && regex.IsMatch(phoneNumber);
        }
    }
}
