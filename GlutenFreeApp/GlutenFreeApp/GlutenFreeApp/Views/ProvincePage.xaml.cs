using Xamarin.Forms;
using GlutenFreeApp.Models;
using System.Linq;
using System.Collections.Generic;
using GlutenFreeApp.ViewModels;

namespace GlutenFreeApp.Views
{
    public partial class ProvincePage : ContentPage
    {
        public ProvincePage()
        {
            InitializeComponent();
            BindingContext = new ProvinceViewModel();
        }
        
        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ProvinceCollectionView.ItemsSource = GetList(e.NewTextValue);
        }

        private IEnumerable<Provincia> GetList(string nomeProvincia = null)
        {
            ProvinceViewModel _container = BindingContext as ProvinceViewModel;
            IList<Provincia> province = _container.ListaProvince;
            
            return string.IsNullOrEmpty(nomeProvincia) ? province : province
                .Where(p => p.Nome.ToLower()
                .StartsWith(nomeProvincia.ToLower()));
        }
    }
}