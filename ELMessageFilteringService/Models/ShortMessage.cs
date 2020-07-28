namespace ELMessageFilteringService.Models
{
    public abstract class ShortMessage : Message
    {
        public override string Content { get; set; } //TODO > must be max 140 characters

        public void SanitizeText()
        {

        }
    }
}
