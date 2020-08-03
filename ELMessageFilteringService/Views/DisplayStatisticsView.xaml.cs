using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Services;
using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for DisplayStatisticsView.xaml
    /// </summary>
    public partial class DisplayStatisticsView : UserControl
    {
        public DisplayStatisticsView()
        {
            InitializeComponent();

            IDataProvider dataProvider = new DataProvider();
            IStatisticsService statisticsService = new StatisticsService(dataProvider);
            DataContext = new DisplayStatisticsViewModel(statisticsService);
        }
    }
}
