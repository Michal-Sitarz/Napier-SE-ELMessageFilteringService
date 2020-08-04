using ELMessageFilteringService.Models;
using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for DisplayMessageView.xaml
    /// </summary>
    public partial class DisplayMessageView : UserControl
    {
        public DisplayMessageView(Message message)
        {
            InitializeComponent();

            DataContext = new DisplayMessageViewModel(message);
        }
    }
}
