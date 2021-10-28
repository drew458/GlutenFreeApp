using MCtabbed2.ViewModels;
using MCtabbed2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MCtabbed2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("regionidetails", typeof(RegioniDetailPage));
        }

    }
}
