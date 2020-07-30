using ELMessageFilteringService.Commands;
using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace ELMessageFilteringService.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //private readonly IDataProvider _dataProvider;

        #region UI Binding Fields
        public string HomeButtonContent { get; private set; }
        public string AddMessageButtonContent { get; private set; }
        public string ImportMessagesButtonContent { get; private set; }
        public string DisplayStatisticsButtonContent { get; private set; }
        
        public ICommand HomeButtonCommand { get; private set; }
        public ICommand AddMessageButtonCommand { get; private set; }
        public ICommand ImportMessagesButtonCommand { get; private set; }
        public ICommand DisplayStatisticsButtonCommand { get; private set; }

        public UserControl ContentControlBinding { get; private set; }
        #endregion

        #region Constructor
        public MainWindowViewModel(/*IDataProvider dataProvider*/)
        {
            //_dataProvider = dataProvider;

            HomeButtonContent = "Home";
            AddMessageButtonContent = "Add New Message";
            ImportMessagesButtonContent = "Import Messages";
            DisplayStatisticsButtonContent = "Display Statistics";

            HomeButtonCommand = new RelayCommand(HomeButtonClick);
            AddMessageButtonCommand = new RelayCommand(AddMessageButtonClick);
            ImportMessagesButtonCommand = new RelayCommand(ImportMessagesButtonClick);
            DisplayStatisticsButtonCommand = new RelayCommand(DisplayStatisticsButtonClick);

            ContentControlBinding = new DefaultView();
        }
        #endregion

        #region Click Helpers
        private void HomeButtonClick()
        {
            ContentControlBinding = new DefaultView();
            OnChanged(nameof(ContentControlBinding));
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
        #endregion

        #region Other Helpers
        //public void UpdateViewModel(UserControl x)
        //{
        //    ContentControlBinding = x;
        //    OnChanged(nameof(ContentControlBinding));
        //}
        #endregion
    }
}
