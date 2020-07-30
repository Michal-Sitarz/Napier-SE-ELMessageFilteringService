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
            DataContext = new ImportMessagesViewModel();
        }
    }
}
