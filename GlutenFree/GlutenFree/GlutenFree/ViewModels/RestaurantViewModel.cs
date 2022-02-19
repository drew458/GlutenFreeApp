using GlutenFreeApp.Models;
using GlutenFreeApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GlutenFreeApp.ViewModels
{
    [QueryProperty(nameof(Nome), nameof(Nome))]
    [QueryProperty(nameof(Indirizzo), nameof(Indirizzo))]
    public class RestaurantViewModel : BaseViewModel, IQueryAttributable
    {
        private int idRistorante;
        private string nomeRistorante;
        private string indirizzoRistorante;
        private string cittaRistorante;
        private string tipoCucina;
        private string url;

        public Command VisitWebsiteButtonTapped { get; }

        public RestaurantViewModel()
        {
            Title = Nome;
            VisitWebsiteButtonTapped = new Command(OnVisitWebsiteButtonTappedAsync);
        }

        public int ID
        {
            get => idRistorante;
            set
            {
                idRistorante = value;
            }
        }
        public string Nome
        {
            get => nomeRistorante;
            set
            {
                nomeRistorante = value;
                OnPropertyChanged();
            }
        }
        public string Indirizzo
        {
            get => indirizzoRistorante;
            set
            {
                indirizzoRistorante = value;
                OnPropertyChanged();
            }
        }
        public string Citta
        {
            get => cittaRistorante;
            set
            {
                cittaRistorante = value;
                OnPropertyChanged();
            }
        }
        public string TipoCucina
        {
            get => tipoCucina;
            set
            {
                tipoCucina = value;
                OnPropertyChanged();
            }
        }
        public string URL
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged();
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            try
            {
                string nome = HttpUtility.UrlDecode(query["Nome"]);
                string indirizzo = HttpUtility.UrlDecode(query["Indirizzo"]);
                LoadRistorante(nome, indirizzoRistorante);
            }
            catch (Exception)
            {
                Int32.TryParse(HttpUtility.UrlDecode(query["ID"]), out int id);

                LoadRistorante(id);
            }
        }

        internal void OnAppearing()
        {
            
        }

        private async void LoadRistorante(int idRistorante)
        {
            try
            {
                LocalRestaurantService localDb = await LocalRestaurantService.Instance;

                Restaurant ristorante = RestaurantFromQuery2RestaurantService.Convert(await localDb.GetRestaurantAsync(idRistorante));
                
                Nome = ristorante.Nome;
                Indirizzo = ristorante.Indirizzo;
                Citta = ristorante.Citta;
                TipoCucina = ristorante.TipoCucina;
                URL = ristorante.URL;
            }
            catch (Exception)
            {
                Console.WriteLine("Impossibile caricare il ristorante");
            }
        }

        private async void LoadRistorante(string nomeRistorante, string indirizzoRistorante)
        {
            try
            {
                LocalRestaurantService localDb = await LocalRestaurantService.Instance;

                List<Restaurant> ristoranti = RestaurantFromQuery2RestaurantService.Convert(await localDb.GetRestaurantAsyncName(nomeRistorante));
                foreach(Restaurant ristorante in ristoranti)
                {
                    if (ristorante.Indirizzo.Equals(indirizzoRistorante))
                    {
                        Nome = ristorante.Nome;
                        Indirizzo = ristorante.Indirizzo;
                        Citta = ristorante.Citta;
                        TipoCucina = ristorante.TipoCucina;
                        URL = ristorante.URL;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Impossibile caricare il ristorante");
            }
        }

        private async void OnVisitWebsiteButtonTappedAsync()
        {
            await Browser.OpenAsync(this.URL, BrowserLaunchMode.SystemPreferred);
        }
    }
}
