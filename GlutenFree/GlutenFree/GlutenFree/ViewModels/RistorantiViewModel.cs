using GlutenFree.Models;
using GlutenFree.Resx;
using GlutenFree.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    public class RistorantiViewModel : BaseViewModel
    {
        public ObservableCollection<Restaurant> ListaRistoranti { get; }
        public Restaurant _ristoranteSelezionato;

        private readonly RemoteRestaurantService remoteDbService;

        public Command<Restaurant> RistoranteTapped { get; }
        public Command LoadRistorantiCommand { get; }

        public RistorantiViewModel()
        {
            Title = AppResources.StringRestaurants;
            ListaRistoranti = new ObservableCollection<Restaurant>();

            remoteDbService = new RemoteRestaurantService();

            LoadRistorantiCommand = new Command(async () => await ExecuteLoadRistorantiCommand());
            RistoranteTapped = new Command<Restaurant>(OnRistoranteSelezionato);
        }

        private async Task ExecuteLoadRistorantiCommand()
        {
            IsBusy = true;

            try
            {
                ListaRistoranti.Clear();
                var ristoranti = RestaurantFromQuery2RestaurantService.Convert(await remoteDbService.GetRestaurantsAsync());
                foreach (var ristorante in ristoranti)
                {
                    ListaRistoranti.Add(ristorante);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            RistoranteSelezionato = null;
        }

        public Restaurant RistoranteSelezionato
        {
            get => _ristoranteSelezionato;
            set
            {
                SetProperty(ref _ristoranteSelezionato, value);
                OnRistoranteSelezionato(value);
            }
        }

        async void OnRistoranteSelezionato(Restaurant ristorante)
        {
            if (ristorante == null)
            {
                return;
            }

            //await Shell.Current.GoToAsync($"{nameof(ProvincePage)}?{nameof(ProvinceViewModel.Nome)}={ristorante.Nome}");
        }
    }
}
