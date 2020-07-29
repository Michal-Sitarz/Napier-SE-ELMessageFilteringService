using ELMessageFilteringService.Services;
using ELMessageFilteringService.ViewModels;
using System.Windows.Controls;

namespace ELMessageFilteringService.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddMessageView : UserControl
    {
        public AddMessageView()
        {
            InitializeComponent();

            MessageService service = new MessageService();
            DataContext = new AddMessageViewModel(service);
        }
    }
}
