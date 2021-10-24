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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
