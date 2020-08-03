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
        public string HeaderTextBlock { get; private set; }
        public string BodyTextBlock { get; private set; }

        public string HeaderTextBox { get; set; }
        public string BodyTextBox { get; set; }

        public string AddNewMessageButtonContent { get; private set; }
        public string ClearButtonContent { get; private set; }

        public ICommand AddNewMessageButtonCommand { get; private set; }
        public ICommand ClearButtonCommand { get; private set; }
        #endregion

        #region Constructor
        public AddMessageViewModel(IMessageService messageService)
        {
            _messageService = messageService;

            HeaderTextBlock = "Message Header";
            BodyTextBlock = "Message Body";
            HeaderTextBox = string.Empty;
            BodyTextBox = string.Empty;

            AddNewMessageButtonContent = "Submit";
            ClearButtonContent = "Clear";
            AddNewMessageButtonCommand = new RelayCommand(AddNewMessageButtonClick);
            ClearButtonCommand = new RelayCommand(ClearButtonClick);

        }
        #endregion

        #region Click Helpers
        private void AddNewMessageButtonClick()
        {
            var message = new RawMessage
            {
                //Header = HeaderTextBox,
                Header = HeaderTextBox + "123456789", // <- only for testing the UI
                Body = BodyTextBox
            };

            if (message.IsValid())
            {
                var newMsg = _messageService.AddNewMessage(message);
                if (newMsg != null)
                {
                    //Display newly added message in a new Window using DisplayViewModel
                    MessageBox.Show($"New {newMsg.Type} message has been added.\n\nSender: {newMsg.Sender}\nContent:\n{newMsg.Content}");
                    ClearInputFields();

                    

                }
            }
            else
            {
                MessageBox.Show("Message has NOT been added!\n\nMessage body cannot be empty.\nMessage header has to be 10 characters long \nwith first letter indicating message type: \nS -> SMS, T -> Tweet, E -> Email,\nfollowed by 9 digits.");
            }
        }

        private void ClearButtonClick()
        {
            ClearInputFields();
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
