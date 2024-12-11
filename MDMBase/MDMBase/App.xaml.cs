using MDMBase.ViewModel.MainView;
using MDMBase.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Application = System.Windows.Application;

namespace MDMBase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            // MainWindow 실행
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ViewModel 등록
            services.AddSingleton<MainViewModel>();
            
            //services.AddSingleton<LockViewModel>();

            // View 등록
            services.AddTransient<MainWindow>();
            services.AddTransient<LockWindow>();
        }

    }

}
