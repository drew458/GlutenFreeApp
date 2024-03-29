﻿using GlutenFreeApp.Models;
using GlutenFreeApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlutenFreeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RistorantiPage : ContentPage
    {
        readonly RistorantiViewModel _viewModel;

        public RistorantiPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RistorantiViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RistorantiCollectionView.ItemsSource = GetList(e.NewTextValue);
        }

        private IEnumerable<Restaurant> GetList(string nomeRistorante = null)
        {
            RistorantiViewModel _container = BindingContext as RistorantiViewModel;
            IList<Restaurant> ristoranti = _container.ListaRistoranti;

            return string.IsNullOrEmpty(nomeRistorante) ? ristoranti : ristoranti
                .Where(r => r.Nome.ToLower()
                .StartsWith(nomeRistorante.ToLower()));
        }
    }
}