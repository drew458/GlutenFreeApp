using GlutenFree.Resx;
using GlutenFree.Views;
using System;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginButtonTapped { get; }
        public Command RegistrationButtonTapped { get; }

        public LoginViewModel()
        {
            Title = AppResources.StringLogin;
            LoginButtonTapped = new Command(OnLoginButtonTapped);
            RegistrationButtonTapped = new Command(OnRegistrationButtonTapped);
        }

        public void OnAppearing()
        {

        }

        private async void OnLoginButtonTapped()
        {
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}
