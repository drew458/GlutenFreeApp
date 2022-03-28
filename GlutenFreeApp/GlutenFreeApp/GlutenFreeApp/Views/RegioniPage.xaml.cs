using GlutenFreeApp.Models;
using GlutenFreeApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace GlutenFreeApp.Views
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

        private IEnumerable<Regione> GetList(string nomeRegione = null)
        {
            RegioniViewModel _container = BindingContext as RegioniViewModel;
            IList<Regione> regioni = _container.ListaRegioni;

            return string.IsNullOrEmpty(nomeRegione) ? regioni : regioni
                .Where(r => r.Nome.ToLower()
                .StartsWith(nomeRegione.ToLower()));
        }
    }
}