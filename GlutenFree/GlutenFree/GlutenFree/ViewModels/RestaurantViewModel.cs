using GlutenFree.Services;
using System;

namespace GlutenFree.ViewModels
{
    public class RestaurantViewModel : BaseViewModel
    {
        private int idRistorante;
        private string nomeRistorante;
        private string indirizzoRistorante;

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
            }
        }
        public string Indirizzo
        {
            get => indirizzoRistorante;
            set
            {
                indirizzoRistorante = value;
            }
        }

        internal void OnAppearing()
        {
            
        }

        private async void LoadRistorante(int idRistorante)
        {
            LocalRestaurantService localDb = await LocalRestaurantService.Instance;

            var ristorante = await localDb.GetRestaurantAsync(idRistorante);
            this.Nome = ristorante.Nome;
            this.Indirizzo = ristorante.Indirizzo;
        }
    }
}
