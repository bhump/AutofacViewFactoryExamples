using System;
using System.Threading.Tasks;
using CommonServiceLocator;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DependencyInjectionExamples
{
    public partial class App : Application
    {
        ISettingsService _settingsService;

        public App()
        {
            InitializeComponent();

            Bootstrapper.Initialize();
        }

        protected override async void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //private void InitApp()
        //{
        //    Bootstrapper.Run();

        //    _settingsService = ViewModelLocator.Resolve<ISettingsService>();
        //    if (!_settingsService.UseMocks)
        //        ViewModelLocator.UpdateDependencies(_settingsService.UseMocks);
        //}

        //private Task InitNavigation()
        //{
        //    var navigationService = ViewModelLocator.Resolve<INavigationService>();
        //    return navigationService.InitializeAsync();
        //}
    }
}
