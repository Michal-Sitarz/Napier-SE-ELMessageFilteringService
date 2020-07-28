namespace ELMessageFilteringService.Models
{
    public class Email : Message
    {
        public override string Content { get; set; }
        public override string Sender { get; set; }

        public string Subject { get; set; }
        public bool IsSIR { get; set; }
    }
}
