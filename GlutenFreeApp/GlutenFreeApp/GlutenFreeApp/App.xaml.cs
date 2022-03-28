using GlutenFreeApp.Services;
using GlutenFreeApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GlutenFreeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<Helpers.IMessageService, Helpers.MessageService>();
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
            
            var expiryDate = Preferences.Get("expiry_date", DateTime.Now.Subtract(TimeSpan.FromDays(3)));
            if (DateTime.Compare(expiryDate, DateTime.Now) > 0)
            {
                Shell.Current.GoToAsync($"//{nameof(MapPage)}");
            }
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
