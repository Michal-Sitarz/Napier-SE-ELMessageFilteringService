using ELMessageFilteringService.Commands;
using ELMessageFilteringService.Models;
using ELMessageFilteringService.Models.Enums;
using ELMessageFilteringService.Services;
using ELMessageFilteringService.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ELMessageFilteringService.ViewModels
{
    public class AddMessageViewModel : BaseViewModel
    {
        private readonly IMessageService _messageService;

        #region UI Binding Fields
        // texts
        public string HeaderTextBlock { get; private set; }
        public string BodyTextBlock { get; private set; }

        public string HeaderTextBox { get; set; }
        public string BodyTextBox { get; set; }

        // buttons
        public string AddNewMessageButtonContent { get; private set; }
        public string ClearButtonContent { get; private set; }
        public string CloseMessageButtonContent { get; private set; }

        public ICommand AddNewMessageButtonCommand { get; private set; }
        public ICommand ClearButtonCommand { get; private set; }
        public ICommand CloseMessageButtonCommand { get; private set; }

        public bool CloseMessageButtonVisibility { get; set; }

        public UserControl ContentControlBinding { get; private set; }
        #endregion

        #region Constructor
        public AddMessageViewModel(IMessageService messageService)
        {
            _messageService = messageService;

            // texts
            HeaderTextBlock = "Message Header";
            BodyTextBlock = "Message Body";

            HeaderTextBox = string.Empty;
            BodyTextBox = string.Empty;

            // buttons
            AddNewMessageButtonContent = "Submit";
            ClearButtonContent = "Clear";
            CloseMessageButtonContent = "Close Message";

            AddNewMessageButtonCommand = new RelayCommand(AddNewMessageButtonClick);
            ClearButtonCommand = new RelayCommand(ClearButtonClick);
            CloseMessageButtonCommand = new RelayCommand(CloseMessageButtonClick);

            CloseMessageButtonVisibility = false;

        }
        #endregion

        #region Click Helpers
        private void AddNewMessageButtonClick()
        {
            
            if (CloseMessageButtonVisibility) // VALIDATE if there is already a message displayed
            {
                MessageBox.Show("Please close currently displayed message before adding a new one.");
            }
            else
            {
                var message = new RawMessage
                {
                    Header = HeaderTextBox,
                    Body = BodyTextBox
                };

                if (message.IsValid())
                {
                    var newMsg = _messageService.AddNewMessage(message);
                    if (newMsg != null)
                    {
                        // DISPLAY Newly Added Message
                        ContentControlBinding = new DisplayMessageView(newMsg);
                        OnChanged(nameof(ContentControlBinding));

                        CloseMessageButtonVisibility = true;
                        OnChanged(nameof(CloseMessageButtonVisibility));
                    }
                }
                else
                {
                    MessageBox.Show("Message has NOT been added!\n\nMessage body cannot be empty.\nMessage header has to be 10 characters long \nwith first letter indicating message type: \nS -> SMS, T -> Tweet, E -> Email,\nfollowed by 9 digits.");
                }
            }
        }

        private void ClearButtonClick()
        {
            ClearInputFields();
        }

        private void CloseMessageButtonClick()
        {
            ClearInputFields();

            ContentControlBinding = new DefaultView();
            OnChanged(nameof(ContentControlBinding));

            CloseMessageButtonVisibility = false;
            OnChanged(nameof(CloseMessageButtonVisibility));
        }
        #endregion

        #region Other Helper Methods
        private void ClearInputFields()
        {
            HeaderTextBox = string.Empty;
            BodyTextBox = string.Empty;
            OnChanged(nameof(HeaderTextBox));
            OnChanged(nameof(BodyTextBox));
        }
        #endregion
    }
}
