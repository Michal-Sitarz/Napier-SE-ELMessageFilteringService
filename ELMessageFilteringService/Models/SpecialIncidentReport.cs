namespace ELMessageFilteringService.Models
{
    public class SpecialIncidentReport : Email
    {
        public string SportCentreCode { get; set; }
        public string NatureOfIncident { get; set; }
    }
}
