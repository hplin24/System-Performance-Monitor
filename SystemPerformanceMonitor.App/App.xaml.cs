using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using SystemPerformanceMonitor.App.ViewModels;
using SystemPerformanceMonitor.App.Views;
using SystemPerformanceMonitor.Core.Interfaces;
using SystemPerformanceMonitor.Core.Services;
using SystemPerformanceMonitor.Infrastructure.Metrics;

namespace SystemPerformanceMonitor.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IMetricsCollector, WindowsMetricsCollector>();
            services.AddSingleton<MetricsService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        
    }

}
