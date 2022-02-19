using GlutenFreeApp.Models;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GlutenFreeApp.ViewModels
{
    [QueryProperty(nameof(Nome), nameof(Nome))]
    public class ProvinceViewModel : BaseViewModel
    {
        private string nomeRegione;
        private IList<Provincia> listaProvince;
        public Command<Provincia> ProvinciaTapped { get; }

        public string Nome
        {
            get => nomeRegione;

            set
            {
                nomeRegione = value;
                LoadProvince(value);
            }
        }

        public IList<Provincia> ListaProvince
        {
            get => listaProvince;
            set
            {
                listaProvince = value;
                OnPropertyChanged();
            }
        }

        public ProvinceViewModel()
        {
            Title = AppResources.StringProvinces;
            ProvinciaTapped = new Command<Provincia>(OnProvinciaSelezionata);
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

        private async void OnProvinciaSelezionata(Provincia provincia)
        {
            if (provincia == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(RistorantiNellaProvinciaPage)}?{nameof(RistorantiNellaProvinciaViewModel.Provincia)}={provincia.Nome}");
        }
    }
}
