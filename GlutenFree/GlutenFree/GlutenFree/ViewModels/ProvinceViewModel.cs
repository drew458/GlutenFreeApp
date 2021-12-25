using GlutenFree.Models;
using GlutenFree.Resx;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    [QueryProperty(nameof(Nome), nameof(Nome))]
    public class ProvinceViewModel : BaseViewModel
    {
        private string nomeRegione;
        private IList<Provincia> listaProvince;

        // per capire auto-property, guardare https://www.w3schools.com/cs/cs_properties.php
        // per capire OnPropertyChanged(), guardare https://stackoverflow.com/questions/57442915/how-to-set-listview-itemssource-to-a-viewmodel-in-xamarin

        // auto-property
        public IList<Provincia> ListaProvince
        {
            get
            {
                return listaProvince;
            }

            set
            {
                listaProvince = value;
                OnPropertyChanged();
            }
        }

        public string Nome
        {
            get => nomeRegione;

            set
            {
                nomeRegione = value;
                LoadProvince(value);
            }
        }

        public ProvinceViewModel()
        {
            Title = AppResources.StringProvinces;
        }

        public async void LoadProvince(string nomeRegione)
        {
            try
            {
                Regione regione = await DataStore.GetItemAsync(nomeRegione);
                IList<Provincia> province = regione.Province;
                ListaProvince = province;
            }
            catch (Exception)
            {
                Console.WriteLine("Impossibile caricare la provincia");
            }
        }
    }
}
