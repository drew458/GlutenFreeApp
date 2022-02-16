using GlutenFreeApp.Helpers;
using GlutenFreeApp.Resources;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Views;
using System;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GlutenFreeApp.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public Command RegistrationButtonTapped { get; }
        private readonly HttpClient client;
        private readonly IMessageService _messageService;

        string _emailEntry;
        string _passwordEntry;
        string _repeatedPasswordEntry;
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
        public string RepeatedPasswordEntry
        {
            get { return _repeatedPasswordEntry; }
            set
            {
                SetProperty(ref _repeatedPasswordEntry, value);
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

        public RegistrationViewModel()
        {
            Title = AppResources.StringRegistration;
            RegistrationButtonTapped = new Command(OnRegistrationButtonTapped);
            client = new HttpClient();
            this._messageService = DependencyService.Get<IMessageService>();
        }

        public void OnAppearing()
        {

        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            ActivityIndicatorSpinning = true;

            if (!EmailEntry.Contains("@"))
            {
                ActivityIndicatorSpinning = false;
                await _messageService.ShowPopUpAsync("Registration error", "Email not valid", "OK");
                PasswordEntry = null;
            }

            // Check if the password meets the requirements (special character, number, uppercase)
            if (EmailPasswordCheckService.CheckPassword(PasswordEntry))
            {
                // Check if the password match the reapeated password
                if (PasswordEntry.Equals(RepeatedPasswordEntry))
                {
                    try
                    {
                        var sanitizedEmail = EmailPasswordCheckService.SanitizeEmail(EmailEntry);
                        var hashedPassword = EncryptionService.Encrypt(sanitizedEmail, PasswordEntry);

                        string apiUrl = Constants.APIUserRegistration + "&em=" + 
                             sanitizedEmail + "&pwd=" + hashedPassword;
                        
                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        try
                        {
                            response.EnsureSuccessStatusCode();
                        }
                        catch (Exception)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        ActivityIndicatorSpinning = false;
                        await _messageService.ShowPopUpAsync("Login error", "Wrong email or password", "OK");
                        PasswordEntry = null;
                        RepeatedPasswordEntry = null;
                    }

                    // SUCCESS!
                    var expiryDate = DateTime.Now.AddDays(30);
                    Preferences.Set("expiry_date", expiryDate);
                    await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                }
                else
                {
                    await _messageService.ShowPopUpAsync("Registration error", "Password inserted does not match", "OK");
                    PasswordEntry = null;
                    RepeatedPasswordEntry = null;
                }
            }
            else
            {
                ActivityIndicatorSpinning = false;
                await _messageService.ShowPopUpAsync("Registration error", 
                    "Password must cointain at least on special character, a number and an upper case letter", "OK");
                PasswordEntry = null;
                RepeatedPasswordEntry = null;
            }
        }
    }
}
