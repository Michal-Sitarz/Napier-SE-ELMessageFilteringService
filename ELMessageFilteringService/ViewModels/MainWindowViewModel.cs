using ELMessageFilteringService.Commands;
using ELMessageFilteringService.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace ELMessageFilteringService.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string AddMessageButtonContent { get; private set; }
        public string ImportMessagesButtonContent { get; private set; }
        public string DisplayStatisticsButtonContent { get; private set; }
        
        public ICommand AddMessageButtonCommand { get; private set; }
        public ICommand ImportMessagesButtonCommand { get; private set; }
        public ICommand DisplayStatisticsButtonCommand { get; private set; }

        public UserControl ContentControlBinding { get; private set; }

        public MainWindowViewModel()
        {
            AddMessageButtonContent = "Add Message";
            ImportMessagesButtonContent = "Import Messages";
            DisplayStatisticsButtonContent = "Display Statistics";

            AddMessageButtonCommand = new RelayCommand(AddMessageButtonClick);
            ImportMessagesButtonCommand = new RelayCommand(ImportMessagesButtonClick);
            DisplayStatisticsButtonCommand = new RelayCommand(DisplayStatisticsButtonClick);

            ContentControlBinding = new DefaultView();
        }

        private void AddMessageButtonClick()
        {
            ContentControlBinding = new AddMessageView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ImportMessagesButtonClick()
        {
            ContentControlBinding = new ImportMessagesView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void DisplayStatisticsButtonClick()
        {
            ContentControlBinding = new DisplayStatisticsView();
            OnChanged(nameof(ContentControlBinding));
        }
    }
}
