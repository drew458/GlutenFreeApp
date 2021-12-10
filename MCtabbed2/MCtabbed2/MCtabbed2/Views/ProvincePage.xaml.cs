using Xamarin.Forms;
using MCtabbed2.Models;
using MCtabbed2.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using MCtabbed2.ViewModels;
using System.Collections;

namespace MCtabbed2.Views
{
    public partial class ProvincePage : ContentPage
    {
        public ProvincePage()
        {
            InitializeComponent();
            BindingContext = new ProvinceViewModel();
        }


        /* from https://www.youtube.com/watch?v=_YefBlDAUHA & http://xamaringuyshow.com/2018/12/08/xamrin-forms-search-item-on-listview-mvvm-easy-approach/
         * void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as ProvinceViewModel;
            //ProvinceCollectionView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ProvinceCollectionView.ItemsSource = _container.ListaProvince;
            else
                ProvinceCollectionView.ItemsSource = _container.ListaProvince.Where(i => i.Nome.Contains(e.NewTextValue));

            //EmployeeListView.EndRefresh();
        } */

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