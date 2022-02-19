using GlutenFreeApp.Models;
using GlutenFreeApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlutenFreeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RistorantiNellaProvinciaPage : ContentPage
    {
        readonly RistorantiNellaProvinciaViewModel _viewModel;

        public RistorantiNellaProvinciaPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RistorantiNellaProvinciaViewModel();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RistorantiNellaProvinciaCollectionView.ItemsSource = GetList(e.NewTextValue);
        }

        private IEnumerable<Restaurant> GetList(string nomeRistorante = null)
        {
            RistorantiNellaProvinciaViewModel _container = BindingContext as RistorantiNellaProvinciaViewModel;
            IList<Restaurant> ristoranti = _container.ListaRistoranti;

            return string.IsNullOrEmpty(nomeRistorante) ? ristoranti : ristoranti
                .Where(p => p.Nome.ToLower()
                .StartsWith(nomeRistorante.ToLower()));
        }
    }
}