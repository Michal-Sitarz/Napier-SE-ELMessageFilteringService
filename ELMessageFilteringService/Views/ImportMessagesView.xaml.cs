using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Services;
using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for ImportMessagesView.xaml
    /// </summary>
    public partial class ImportMessagesView : UserControl
    {
        public ImportMessagesView()
        {
            InitializeComponent();

            DataProvider dataProvider = new DataProvider();
            MessageService service = new MessageService(dataProvider);
            DataContext = new ImportMessagesViewModel(service);
        }
    }
}
