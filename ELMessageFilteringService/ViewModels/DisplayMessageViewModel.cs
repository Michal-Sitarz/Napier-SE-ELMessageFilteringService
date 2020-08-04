using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ELMessageFilteringService.Models.Enums;

namespace ELMessageFilteringService.ViewModels
{
    public class DisplayMessageViewModel : BaseViewModel
    {
        private Message _message;

        #region UI Binding Fields

        public string NewMessageLabel { get; set; }

        public string IdTextBlock { get; private set; }
        public string TypeTextBlock { get; private set; }
        public string SenderTextBlock { get; private set; }
        public string ContentTextBlock { get; private set; }
        public string SubjectTextBlock { get; private set; }
        public string IsSIRTextBlock { get; private set; }
        public string SportCentreCodeTextBlock { get; private set; }
        public string NatureOfIncidentTextBlock { get; private set; }

        public string IdTextBox { get; set; }
        public string TypeTextBox { get; set; }
        public string SenderTextBox { get; set; }
        public string ContentTextBox { get; set; }
        public string SubjectTextBox { get; set; }
        public string IsSIRTextBox { get; set; }
        public string SportCentreCodeTextBox { get; set; }
        public string NatureOfIncidentTextBox { get; set; }

        public bool SubjectVisibility { get; private set; }
        public bool IsSIRVisibility { get; private set; }
        public bool SportCentreCodeVisibility { get; private set; }
        public bool NatureOfIncidentVisibility { get; private set; }

        #endregion

        #region Constructor
        public DisplayMessageViewModel(Message message)
        {
            _message = message;

            NewMessageLabel = "Added New Message";

            IdTextBlock = "Id";
            TypeTextBlock = "Type";
            SenderTextBlock = "Sender";
            ContentTextBlock = "Content";
            SubjectTextBlock = "Subject";
            IsSIRTextBlock = "Email is SIR";
            SportCentreCodeTextBlock = "Sport Centre Code";
            NatureOfIncidentTextBlock = "Nature of Incident";

            IdTextBox = string.Empty;
            TypeTextBox = string.Empty;
            SenderTextBox = string.Empty;
            ContentTextBox = string.Empty;
            SubjectTextBox = string.Empty;
            IsSIRTextBox = string.Empty;
            SportCentreCodeTextBox = string.Empty;
            NatureOfIncidentTextBox = string.Empty;

            SubjectVisibility = true;
            IsSIRVisibility = true;
            SportCentreCodeVisibility = true;
            NatureOfIncidentVisibility = true;

            UpdateTextBoxes();
        }
        // foreach field in a message -> generate row: textblock + textbox
        #endregion

        #region Click Helpers
        // close button
        #endregion

        #region Other Helper Methods
        private void UpdateTextBoxes()
        {
            IdTextBox = _message.Id;
            TypeTextBox = _message.Type.ToString();
            SenderTextBox = _message.Sender;
            ContentTextBox = _message.Content;

            if (_message.Type == MessageType.Email)
            {
                Email email = (Email)_message;
                SubjectTextBox = email.Subject;

                if (!email.IsSIR)
                {
                    IsSIRTextBox = "No";
                    SportCentreCodeVisibility = false;
                    NatureOfIncidentVisibility = false;
                }
                else
                {
                    IsSIRTextBox = "Yes";

                    SIR sir = (SIR)email;
                    SportCentreCodeTextBox = sir.IncidentDetails.SportCentreCode;
                    NatureOfIncidentTextBox = sir.IncidentDetails.NatureOfIncident;
                }
            }
            else
            {
                SubjectVisibility = false;
                IsSIRVisibility = false;
                SportCentreCodeVisibility = false;
                NatureOfIncidentVisibility = false;
            }

        }
        #endregion
    }
}
