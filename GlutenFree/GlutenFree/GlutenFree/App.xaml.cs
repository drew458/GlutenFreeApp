using GlutenFree.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GlutenFree
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            Helpers.AppTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            Helpers.AppTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Helpers.AppTheme.SetTheme();
            });
        }
    }
}
