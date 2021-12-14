using Xamarin.Forms;

namespace MCtabbed2.Helpers
{
    public static class TheTheme
    {
        public static void SetTheme()
        {
            switch (Settings.Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            // la riga sotto è da usare solo se la app non ha la shell
            // var nav = App.Current.MainPage as Xamarin.Forms.NavigationPage;

            var e = DependencyService.Get<IEnvironment>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                e?.SetStatusBarColor(Color.Black, false);
                // la riga sotto è da usare solo se la app non ha la shell
                /* if (nav != null)
                {
                    nav.BarBackgroundColor = Color.Black;
                    nav.BarTextColor = Color.White;
                } */
            }
            else
            {
                e?.SetStatusBarColor(Color.White, true);
                // la riga sotto è da usare solo se la app non ha la shell
                /* if (nav != null)
                {
                    nav.BarBackgroundColor = Color.White;
                    nav.BarTextColor = Color.Black;
                } */
            }
        }
    }
}
