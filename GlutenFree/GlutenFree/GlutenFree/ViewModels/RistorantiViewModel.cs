using GlutenFree.Models;
using GlutenFree.Resx;
using GlutenFree.Services;
using GlutenFree.Views;
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
            LocalRestaurantService localDb = await LocalRestaurantService.Instance;

            try
            {
                ListaRistoranti.Clear();
                var ristoranti = RestaurantFromQuery2RestaurantService.Convert(await remoteDbService.GetRestaurantsAsync());
                foreach (var ristorante in ristoranti)
                {
                    ListaRistoranti.Add(ristorante);
                    await localDb.AddRestaurantAsync(ristorante.ID, ristorante.Nome, ristorante.Indirizzo, ristorante.Citta, ristorante.Provincia.Nome,
                        ristorante.Regione.Nome, ristorante.Latitudine, ristorante.Longitudine, 
                        ristorante.TipoCucina.IdTipoCucina, ristorante.MenuAParte, ristorante.ImageId);
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

            await Shell.Current.GoToAsync($"{nameof(RestaurantPage)}?{nameof(RestaurantViewModel.ID)}={ristorante.ID}");
        }
    }
}
