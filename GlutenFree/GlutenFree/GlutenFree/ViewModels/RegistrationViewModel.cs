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
            var hashedPassword = EncryptionService.Encrypt(EmailEntry.ToLower(), PasswordEntry);

            // Checks if the password contains at least one character
            if(PasswordEntry.Contains("?") || PasswordEntry.Contains("!") || PasswordEntry.Contains("&") ||
                PasswordEntry.Contains("$") || PasswordEntry.Contains("=") || PasswordEntry.Contains("_") ||
                PasswordEntry.Contains("^") || PasswordEntry.Contains("@") || PasswordEntry.Contains("%") ||
                PasswordEntry.Contains("'") || PasswordEntry.Contains("(") || PasswordEntry.Contains(")") ||
                PasswordEntry.Contains("*") || PasswordEntry.Contains("+") || PasswordEntry.Contains(",") ||
                PasswordEntry.Contains(".") || PasswordEntry.Contains("/") || PasswordEntry.Contains(":") ||
                PasswordEntry.Contains(";") || PasswordEntry.Contains("<") || PasswordEntry.Contains(">") ||
                PasswordEntry.Contains("[") || PasswordEntry.Contains("]") )
            {
                // Checks if the password match the reapeated password
                if (PasswordEntry.Equals(RepeatedPasswordEntry))
                {
                    try
                    {
                        //remove whitespaces
                        string polishedEmail = Regex.Replace(EmailEntry, @"\s+", "");

                        string apiUrl = Constants.APIUserRegistration + "&em=" + polishedEmail.ToLower() + "&pwd=" + hashedPassword;
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
                        EmailEntry = null;
                        PasswordEntry = null;
                    }

                    await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                }
                else
                {
                    await _messageService.ShowPopUpAsync("Registration error", "Password inserted does not match", "OK");
                    EmailEntry = null;
                    PasswordEntry = null;
                }
            }
            else
            {
                await _messageService.ShowPopUpAsync("Registration error", "Password must cointain at least on special character", 
                    "OK");
                EmailEntry = null;
                PasswordEntry = null;
            }
        }
    }
}
