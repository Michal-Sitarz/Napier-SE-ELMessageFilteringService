namespace ELMessageFilteringService.Models
{
    public abstract class ShortMessage : Message
    {
        public override string Content { get; set; }

        public void SanitizeText()
        {

        }
    }
}
