using MCtabbed2.Models;
using MCtabbed2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MCtabbed2.Views
{
    public partial class RegioniPage : ContentPage
    {
        RegioniViewModel _viewModel;

        public RegioniPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RegioniViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RegioniCollectionView.ItemsSource = GetList(e.NewTextValue);
        }

        private IEnumerable<Regione> GetList(string nomeProvincia = null)
        {
            RegioniViewModel _container = BindingContext as RegioniViewModel;
            IList<Regione> regioni = _container.ListaRegioni;

            return string.IsNullOrEmpty(nomeProvincia) ? regioni : regioni
                .Where(p => p.Nome.ToLower()
                .StartsWith(nomeProvincia.ToLower()));
        }
    }
}