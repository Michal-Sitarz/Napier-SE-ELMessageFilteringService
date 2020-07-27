using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class DisplayStatisticsView : UserControl
    {
        public DisplayStatisticsView()
        {
            InitializeComponent();
            DataContext = new DisplayStatisticsViewModel();
        }
    }
}
