﻿using Xamarin.Forms;
using GlutenFree.Models;
using System.Linq;
using System.Collections.Generic;
using GlutenFree.ViewModels;

namespace GlutenFree.Views
{
    public partial class ProvincePage : ContentPage
    {
        public ProvincePage()
        {
            InitializeComponent();
            BindingContext = new ProvinceViewModel();
        }


        // alcuni pezzi presi da https://www.youtube.com/watch?v=_YefBlDAUHA & http://xamaringuyshow.com/2018/12/08/xamrin-forms-search-item-on-listview-mvvm-easy-approach/
        // & https://github.com/webmasterdevlin/SearchOnNavBarDemo/blob/master/SearchOnNavBarDemo/SearchOnNavBarDemo/MainPage.xaml.cs
        
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