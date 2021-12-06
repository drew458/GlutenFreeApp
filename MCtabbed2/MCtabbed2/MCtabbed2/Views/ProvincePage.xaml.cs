using Xamarin.Forms;
using MCtabbed2.Models;
using MCtabbed2.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using MCtabbed2.ViewModels;

namespace MCtabbed2.Views
{
    public partial class ProvincePage : ContentPage
    {
        public ProvincePage()
        {
            InitializeComponent();
            BindingContext = new ProvinceViewModel();
        }
    }
}