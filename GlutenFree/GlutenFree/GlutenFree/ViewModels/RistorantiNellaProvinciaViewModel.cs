using GlutenFreeApp.Models;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Services;
using GlutenFreeApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using Xamarin.Forms;

namespace GlutenFreeApp.ViewModels
{
    [QueryProperty(nameof(Provincia), nameof(Provincia))]
    public class RistorantiNellaProvinciaViewModel : BaseViewModel
    {
        private string nomeProvincia;
        private IList<Restaurant> listaRistoranti;
        public Command<Restaurant> RistoranteTapped { get; }

        public string Provincia
        {
            get => nomeProvincia;
            set
            {
                nomeProvincia = value;
                LoadRistoranti(value);
            }
        }

        public IList<Restaurant> ListaRistoranti
        {
            get => listaRistoranti;
            set
            {
                listaRistoranti = value;
                OnPropertyChanged();
            }
        }

        public RistorantiNellaProvinciaViewModel()
        {
            Title = AppResources.StringRestaurants;
            RistoranteTapped = new Command<Restaurant>(OnRistoranteSelezionato); 
        }

        private async void LoadRistoranti(string nomeProvincia)
        {
            try
            {
                LocalRestaurantService localDb = await LocalRestaurantService.Instance;
                
                List<Restaurant> ristoranti = RestaurantFromQuery2RestaurantService.Convert(
                    await localDb.GetRestaurantAsyncProvince(nomeProvincia));
                ListaRistoranti = ristoranti;
            }
            catch (Exception)
            {
                Console.WriteLine("Impossible to load restaurants");
            }
        }

        private async void OnRistoranteSelezionato(Restaurant ristorante)
        {
            if(ristorante == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(RestaurantPage)}?{nameof(RestaurantViewModel.Nome)}={ristorante.Nome}" +
                $"&{nameof(RestaurantViewModel.Indirizzo)}={ristorante.Indirizzo}");
        }
    }
}
