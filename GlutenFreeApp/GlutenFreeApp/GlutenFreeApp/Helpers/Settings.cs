using Xamarin.Essentials;

namespace GlutenFreeApp.Helpers
{
    public static class Settings
    {
        // guardare https://www.youtube.com/watch?v=4w8TQ8njd3w
        // 0 = default, 1 = light, 2 = dark
        const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }
    }
}
