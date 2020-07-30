using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.ViewModels;
using System.Windows;

namespace ELMessageFilteringService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataProvider dataProvider = new DataProvider();
            DataContext = new MainWindowViewModel(/*dataProvider*/);
        }
    }
}
