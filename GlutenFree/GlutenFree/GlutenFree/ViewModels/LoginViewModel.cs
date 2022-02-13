﻿using GlutenFree.Helpers;
using GlutenFree.Resources;
using GlutenFree.Resx;
using GlutenFree.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginButtonTapped { get; }
        public Command RegistrationButtonTapped { get; }

        private HttpClient client;

        string _emailEntry;
        string _passwordEntry;
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

        public LoginViewModel()
        {
            Title = AppResources.StringLogin;
            LoginButtonTapped = new Command(OnLoginButtonTapped);
            RegistrationButtonTapped = new Command(OnRegistrationButtonTapped);
            client = new HttpClient();
        }

        public void OnAppearing()
        {

        }

        private async void OnLoginButtonTapped()
        {
            Exception loginFailedException;
            var hashedPassword = InAppEncryption.Encrypt(EmailEntry.ToLower(), PasswordEntry);
            string apiUrl = Constants.APIUserLogin + "&em=" + EmailEntry.ToLower() + "&pwd=" + hashedPassword;

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception)
                {
                    loginFailedException = new Exception(response.StatusCode.ToString());
                    throw loginFailedException;
                }
                
                await Shell.Current.GoToAsync($"//{nameof(MapPage)}");

                //string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Login error: " + e.Message);
            }
        }

        private async void OnRegistrationButtonTapped(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}
