using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ELMessageFilteringService.Models
{
    public class SIR : Email
    {
        public SIRdetails IncidentDetails { get; private set; } = new SIRdetails();

        public void SetSportCentreCodeAndNatureOfIncident()
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
                var _content = Content;
                var centrecode = _content.Substring(0, 9);
                var remainingContent = _content.Substring(10);

                Regex regex = new Regex(@"[0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9]");
                if (regex.IsMatch(centrecode))
                {
                    IncidentDetails.SportCentreCode = centrecode;
                }
                else
                {
                    IncidentDetails.SportCentreCode = "Invalid Code";
                }

                var incidentTypes = new List<string>()
                {
                    "Theft of Properties",
                    "Staff Attack",
                    "Device Damage",
                    "Raid",
                    "Customer Attack",
                    "Staff Abuse",
                    "Bomb Threat",
                    "Terrorism",
                    "Suspicious Incident",
                    "Sport Injury",
                    "Personal Info Leak"
                };

                foreach (var incident in incidentTypes)
                {
                    if (remainingContent.StartsWith(incident))
                    {
                        IncidentDetails.NatureOfIncident = incident;
                        Content = remainingContent.Substring(incident.Length + 1);
                        break;
                    }
                    IncidentDetails.NatureOfIncident = "Unknown";
                }

            }
        }
    }
}
