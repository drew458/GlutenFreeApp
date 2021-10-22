using MC_tabbed.ViewModels;
using MC_tabbed.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MC_tabbed
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
