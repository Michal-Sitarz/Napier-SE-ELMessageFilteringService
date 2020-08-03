using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Services;
using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for DisplayMessageView.xaml
    /// </summary>
    public partial class DisplayMessageView : UserControl
    {
        public DisplayMessageView()
        {
            InitializeComponent();

            DataContext = new DisplayMessageViewModel();
        }
    }
}
