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
            StatisticsService statisticsService = new StatisticsService();
            MessageService messageService = new MessageService(dataProvider, statisticsService);

            DataContext = new ImportMessagesViewModel(messageService);
        }
    }
}
