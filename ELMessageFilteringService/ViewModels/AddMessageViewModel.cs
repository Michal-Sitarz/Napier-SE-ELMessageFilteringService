using ELMessageFilteringService.Commands;
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
        public AddMessageViewModel()
        {
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
            MessageBox.Show("Message has been added.");
            ClearInputFields();
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
