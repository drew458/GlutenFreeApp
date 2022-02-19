using GlutenFreeApp.ViewModels;
using GlutenFreeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GlutenFreeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(ProvincePage), typeof(ProvincePage));
            Routing.RegisterRoute(nameof(RestaurantPage), typeof(RestaurantPage));
            Routing.RegisterRoute(nameof(RistorantiNellaProvinciaPage), typeof(RistorantiNellaProvinciaPage));
        }
    }
}
