using GlutenFreeApp.Models;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Services;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GlutenFreeApp.ViewModels
{
    public class MapViewModel : BaseViewModel
    {        
        private readonly ObservableCollection<MapPin> _luoghi;
        private ObservableCollection<Restaurant> ListaRistoranti { get; }
        private readonly RemoteRestaurantService remoteDbService;
        public IEnumerable Luoghi => _luoghi;
        
        public MapViewModel()
        {
            Title = AppResources.StringMap;
            _luoghi = new ObservableCollection<MapPin>();
            ListaRistoranti = new ObservableCollection<Restaurant>();
            remoteDbService = new RemoteRestaurantService();
            LoadPins();
        }

        private async void LoadPins()
        {
            LocalRestaurantService localDb = await LocalRestaurantService.Instance;

            try
            {
                ListaRistoranti.Clear();
                var ristoranti = RestaurantFromQuery2RestaurantService.Convert(await remoteDbService.GetRestaurantsAsync());
                foreach (var ristorante in ristoranti)
                {
                    ListaRistoranti.Add(ristorante);
                    await localDb.AddRestaurantAsync(ristorante.ID, ristorante.Nome, ristorante.Indirizzo, ristorante.Citta,
                        ristorante.Provincia.Nome, ristorante.Regione.Nome, ristorante.Latitudine, ristorante.Longitudine,
                        ristorante.TipoCucina, ristorante.MenuAParte, ristorante.ImageId, ristorante.URL);

                    _luoghi.Add(new MapPin(ristorante.Indirizzo, ristorante.Nome, ristorante.Posizione));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
