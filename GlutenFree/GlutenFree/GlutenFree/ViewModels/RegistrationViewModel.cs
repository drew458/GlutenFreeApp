using GlutenFree.Resx;
using GlutenFree.Views;
using System;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public Command RegistrationButtonTapped { get; }
        public RegistrationViewModel()
        {
            Title = AppResources.StringRegistration;
            RegistrationButtonTapped = new Command(OnRegistrationButtonTapped);
        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        }

        public void OnAppearing()
        {

        }
    }
}
