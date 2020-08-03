using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ELMessageFilteringService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly ServiceProvider _serviceProvider;

        //public App()
        //{
        //    var serviceCollection = new ServiceCollection();
        //    ConfigureServices(serviceCollection);

        //    _serviceProvider = serviceCollection.BuildServiceProvider();
        //}

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddScoped<IDataProvider, DataProvider>();
        //    services.AddScoped<IMessageService, MessageService>();
        //    services.AddScoped<IStatisticsService, StatisticsService>();
        //}

        //private void AppOnStartup(object sender, StartupEventArgs e)
        //{
        //    var mainWindow = _serviceProvider.GetService<MainWindow>();
        //    mainWindow.Show();
        //}
    }
}
        

