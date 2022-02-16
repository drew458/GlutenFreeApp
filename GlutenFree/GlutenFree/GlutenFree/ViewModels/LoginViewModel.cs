using GlutenFreeApp.Helpers;
using GlutenFreeApp.Resources;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Views;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GlutenFreeApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginButtonTapped { get; }
        public Command RegistrationButtonTapped { get; }
        private readonly HttpClient client;
        private readonly IMessageService _messageService;

        string _emailEntry;
        string _passwordEntry;
        bool _activityIndicatorSpinning;
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
        public bool ActivityIndicatorSpinning
        {
            get { return _activityIndicatorSpinning; }
            set
            {
                SetProperty(ref _activityIndicatorSpinning, value);
            }
        }

        public LoginViewModel()
        {
            Title = AppResources.StringLogin;
            LoginButtonTapped = new Command(OnLoginButtonTapped);
            RegistrationButtonTapped = new Command(OnRegistrationButtonTapped);
            this.client = new HttpClient();
            this._messageService = DependencyService.Get<IMessageService>();
        }

        public void OnAppearing()
        {
            
        }

        private async void OnLoginButtonTapped()
        {
            ActivityIndicatorSpinning = true;

            if (!EmailEntry.Contains("@"))
            {
                ActivityIndicatorSpinning = false;
                await _messageService.ShowPopUpAsync("Login error", "Email not valid", "OK");
                PasswordEntry = null;
            }

            //remove whitespaces
            var sanitizedEmail = EmailPasswordCheckService.SanitizeEmail(EmailEntry);

            var hashedPassword = EncryptionService.Encrypt(sanitizedEmail, PasswordEntry);
            var apiUrl = Constants.APIUserLogin + "&em=" + sanitizedEmail + "&pwd=" + hashedPassword;

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                //string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception)
                {
                    throw new Exception();
                }

                // SUCCESS!
                var expiryDate = DateTime.Now.AddDays(30);
                Preferences.Set("expiry_date", expiryDate);
                await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
            }
            catch (Exception)
            {
                ActivityIndicatorSpinning = false;
                await _messageService.ShowPopUpAsync("Login error", "Wrong email or password", "OK");
                PasswordEntry = null;
            }
        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}
