using GlutenFreeApp.Resources;
using GlutenFreeApp.Helpers;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Views;
using System;
using System.Net.Http;
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
                await _messageService.ShowPopUpAsync(AppResources.LoginErrorTitle, AppResources.LoginErrorDescription, 
                    "OK");
                PasswordEntry = null;
            }

            //remove whitespaces
            var sanitizedEmail = EmailPasswordCheckService.SanitizeEmail(EmailEntry);

            var hashedPassword = EncryptionService.Encrypt(sanitizedEmail, PasswordEntry);
            var apiUrl = Constants.APIUserLogin + "&em=" + sanitizedEmail + "&pwd=" + hashedPassword;

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
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
                await _messageService.ShowPopUpAsync(AppResources.LoginErrorTitle, 
                    AppResources.LoginErrorDescription, "OK");
                PasswordEntry = null;
            }
        }

        private async void OnRegistrationButtonTapped()
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}
