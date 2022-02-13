using GlutenFree.Helpers;
using GlutenFree.Resources;
using GlutenFree.Resx;
using GlutenFree.Views;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
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

            //remove whitespaces
            string polishedEmail = Regex.Replace(EmailEntry, @"\s+", "");

            var hashedPassword = EncryptionService.Encrypt(polishedEmail.ToLower(), PasswordEntry);
            string apiUrl = Constants.APIUserLogin + "&em=" + polishedEmail.ToLower() + "&pwd=" + hashedPassword;

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
                
                await Shell.Current.GoToAsync($"//{nameof(MapPage)}");

                //string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
            }
            catch (Exception)
            {
                ActivityIndicatorSpinning = false;
                await _messageService.ShowPopUpAsync("Login error", "Wrong email or password", "OK");
                EmailEntry = null;
                PasswordEntry = null;
            }
        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}
