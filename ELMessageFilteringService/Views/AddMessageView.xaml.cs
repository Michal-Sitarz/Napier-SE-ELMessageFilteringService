using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Services;
using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for AddMessageView.xaml
    /// </summary>
    public partial class AddMessageView : UserControl
    {
        public AddMessageView()
        {
            InitializeComponent();

            IDataProvider dataProvider = new DataProvider();
            IStatisticsService statisticsService = new StatisticsService(dataProvider);
            IMessageService messageService = new MessageService(dataProvider, statisticsService);

            DataContext = new AddMessageViewModel(messageService);
        }
    }
}
