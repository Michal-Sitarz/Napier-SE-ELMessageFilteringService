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
        private int currentMessageIndex;
        private int importedMessagesCount;

        #region UI Binding Fields
        public string HeaderTextBlock { get; private set; }
        public string BodyTextBlock { get; private set; }

        public string HeaderTextBox { get; set; }
        public string BodyTextBox { get; set; }
        
        public bool HeaderTextBoxIsReadOnly { get; set; }
        public bool BodyTextBoxIsReadOnly { get; set; }

        public string ImportButtonContent { get; private set; }
        public string NextButtonContent { get; private set; }

        public ICommand ImportButtonCommand { get; private set; }
        public ICommand NextButtonCommand { get; private set; }
        #endregion

        #region Constructor
        public ImportMessagesViewModel(MessageService messageService)
        {
            _messageService = messageService;

            HeaderTextBlock = "Message Header (Raw Data)";
            BodyTextBlock = "Message Body (Raw Data)";
            HeaderTextBox = string.Empty;
            BodyTextBox = string.Empty;
            HeaderTextBoxIsReadOnly = true;
            BodyTextBoxIsReadOnly = true;

            ImportButtonContent = "Import";
            NextButtonContent = "Next";
            ImportButtonCommand = new RelayCommand(ImportButtonClick);
            NextButtonCommand = new RelayCommand(NextButtonClick);
        }
        #endregion

        #region Click Helpers
        private void ImportButtonClick()
        {
            if (importedMessagesCount != 0)
            {
                ResetImportedMessages();
            }

            importedMessages = _messageService.GetSimpleMessages();
            importedMessagesCount = importedMessages.Count;
            DisplayMessageInTextBoxes();
            currentMessageIndex++;
        }

        private void NextButtonClick()
        {
            if (currentMessageIndex < importedMessagesCount)
            {
                DisplayMessageInTextBoxes();
                currentMessageIndex++;
            }
            else if(currentMessageIndex != 0)
            {
                ClearTextBoxes();
                MessageBox.Show("No more messages to display.");
                ResetImportedMessages();
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
            if (importedMessagesCount > 0)
            {
                HeaderTextBox = importedMessages[currentMessageIndex].Header;
                BodyTextBox = importedMessages[currentMessageIndex].Body;
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
            importedMessagesCount = 0;
            currentMessageIndex = 0;
        }
        #endregion
    }
}
