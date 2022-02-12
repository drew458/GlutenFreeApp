﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GlutenFree.ViewModels;

namespace GlutenFree.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            BindingContext = new MapViewModel();
        }
    }
}