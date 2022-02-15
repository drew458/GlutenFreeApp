using GlutenFree.ViewModels;
using GlutenFree.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GlutenFree
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        // per capire le "routes", guardare codice nell'esempio:
        // https://github.com/xamarin/xamarin-forms-samples/tree/main/UserInterface/Xaminals

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(ProvincePage), typeof(ProvincePage));
            Routing.RegisterRoute(nameof(RestaurantPage), typeof(RestaurantPage));
        }

    }
}
