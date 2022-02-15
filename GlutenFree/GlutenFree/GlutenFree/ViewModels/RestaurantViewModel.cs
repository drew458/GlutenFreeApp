using GlutenFree.Services;
using System;

namespace GlutenFree.ViewModels
{
    public class RestaurantViewModel : BaseViewModel
    {
        private string nomeRistorante;
        private int idRistorante;

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

        private async void LoadRistorante(int idRistorante)
        {
            LocalRestaurantService localDb = await LocalRestaurantService.Instance;

            var ristorante = await localDb.GetRestaurantAsync(idRistorante);
            this.Nome = ristorante.Nome;
        }
    }
}
