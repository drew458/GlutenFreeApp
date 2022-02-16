using GlutenFreeApp.Models;
using GlutenFreeApp.Services;
using System;

namespace GlutenFreeApp.ViewModels
{
    public class RestaurantViewModel : BaseViewModel
    {
        private int idRistorante;
        private string nomeRistorante;
        private string indirizzoRistorante;
        private string cittaRistorante;

        public RestaurantViewModel()
        {
            Title = Nome;
        }

        public int ID
        {
            get => idRistorante;
            set
            {
                idRistorante = value;
                LoadRistorante(value);
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

        private async void LoadRistorante(int idRistorante)
        {
            try
            {
                LocalRestaurantService localDb = await LocalRestaurantService.Instance;

                Restaurant ristorante = RestaurantFromQuery2RestaurantService.ConvertRestaurant(await localDb.GetRestaurantAsync(idRistorante));
                
                Nome = ristorante.Nome;
                Indirizzo = ristorante.Indirizzo;
                Citta = ristorante.Citta;
            }
            catch (Exception)
            {
                Console.WriteLine("Impossibile caricare il ristorante");
            }
        }
    }
}
