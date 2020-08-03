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

            DataProvider dataProvider = new DataProvider();
            StatisticsService statisticsService = new StatisticsService();
            MessageService messageService = new MessageService(dataProvider, statisticsService);
            
            DataContext = new AddMessageViewModel(messageService);
        }
    }
}
