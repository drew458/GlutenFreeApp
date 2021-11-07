using MCtabbed2.ViewModels;
using MCtabbed2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MCtabbed2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        // per capirne sulle "routes", guardare codice nell'esempio:
        // https://github.com/xamarin/xamarin-forms-samples/tree/main/UserInterface/Xaminals


        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routes.Add("regionidetails", typeof(RegioniDetailPage));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

    }
}
