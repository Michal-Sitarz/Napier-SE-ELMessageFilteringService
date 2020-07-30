using ELMessageFilteringService.Commands;
using ELMessageFilteringService.Models;
using ELMessageFilteringService.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ELMessageFilteringService.ViewModels
{
    public class ImportMessagesViewModel : BaseViewModel
    {
        private readonly MessageService _messageService;

        private IList<MessageDTO> importedMessages;
        private int messageIndex;
        private int messagesCount;

        #region UI Binding Fields
        public string HeaderTextBlock { get; private set; }
        public string BodyTextBlock { get; private set; }

        public string HeaderTextBox { get; set; }
        public string BodyTextBox { get; set; }

        public string ImportButtonContent { get; private set; }
        public string NextButtonContent { get; private set; }

        public ICommand ImportButtonCommand { get; private set; }
        public ICommand NextButtonCommand { get; private set; }
        #endregion

        #region Constructor
        public ImportMessagesViewModel(MessageService messageService)
        {
            _messageService = messageService;

            HeaderTextBlock = "Message Header";
            BodyTextBlock = "Message Body";
            HeaderTextBox = string.Empty;
            BodyTextBox = string.Empty;

            ImportButtonContent = "Import";
            NextButtonContent = "Next";
            ImportButtonCommand = new RelayCommand(ImportButtonClick);
            NextButtonCommand = new RelayCommand(NextButtonClick);
        }
        #endregion

        #region Click Helpers
        private void ImportButtonClick()
        {
            importedMessages = _messageService.GetSimpleMessages();
            messagesCount = importedMessages.Count;
            DisplayMessageInTextBoxes();
            //messageIndex++;
            //enable "Next" button
        }

        private void NextButtonClick()
        {
            if (messageIndex < messagesCount)
            {
                DisplayMessageInTextBoxes();
                messageIndex++;
            }
            else if(messageIndex != 0)
            {
                ClearTextBoxes();
                MessageBox.Show("No more messages to display.");
                ResetImportedMessages();

                //disable "Next" button at the last message
            }
            else
            {
                MessageBox.Show("No messages to display.\nPlease import messages first...");
            }
        }
        #endregion

        #region Other Helper Methods
        private void DisplayMessageInTextBoxes()
        {
            if (messagesCount > 0)
            {
                HeaderTextBox = importedMessages[messageIndex].Header;
                BodyTextBox = importedMessages[messageIndex].Body;
                OnChanged(nameof(HeaderTextBox));
                OnChanged(nameof(BodyTextBox));
            }
        }

        private void ClearTextBoxes()
        {
            HeaderTextBox = string.Empty;
            BodyTextBox = string.Empty;
            OnChanged(nameof(HeaderTextBox));
            OnChanged(nameof(BodyTextBox));
        }

        private void ResetImportedMessages()
        {
            importedMessages = null;
            messagesCount = 0;
            messageIndex = 0;
        }
        #endregion
    }
}
