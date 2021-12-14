using MCtabbed2.ViewModels;
using MCtabbed2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MCtabbed2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        // per capire le "routes", guardare codice nell'esempio:
        // https://github.com/xamarin/xamarin-forms-samples/tree/main/UserInterface/Xaminals

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProvincePage), typeof(ProvincePage));
        }

    }
}
