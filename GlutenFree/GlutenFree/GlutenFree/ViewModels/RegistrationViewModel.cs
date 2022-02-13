using GlutenFree.Resources;
using GlutenFree.Resx;
using GlutenFree.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public Command RegistrationButtonTapped { get; }
        private HttpClient client;

        string _emailEntry;
        string _passwordEntry;
        string _repeatedPasswordEntry;
        public string EmailEntry
        {
            get { return _emailEntry; }
            set
            {
                SetProperty(ref _emailEntry, value);
            }
        }
        public string PasswordEntry
        {
            get { return _passwordEntry; }
            set
            {
                SetProperty(ref _passwordEntry, value);
            }
        }
        public string RepeatedPasswordEntry
        {
            get { return _repeatedPasswordEntry; }
            set
            {
                SetProperty(ref _repeatedPasswordEntry, value);
            }
        }

        public RegistrationViewModel()
        {
            Title = AppResources.StringRegistration;
            RegistrationButtonTapped = new Command(OnRegistrationButtonTapped);
            client = new HttpClient();
        }

        public void OnAppearing()
        {

        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            Exception registrationFailedException;

            if (PasswordEntry.Equals(RepeatedPasswordEntry))
            {
                try
                {
                    string apiUrl = Constants.APIUserRegistration + "&em=" + EmailEntry.ToLower() + "&pwd=" + PasswordEntry;
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    catch (Exception)
                    {
                        registrationFailedException = new Exception(response.StatusCode.ToString());
                        throw registrationFailedException;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Login error: " + ex.Message);
                }

                await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
            }
        }
    }
}
