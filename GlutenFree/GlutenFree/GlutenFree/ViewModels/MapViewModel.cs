using GlutenFreeApp.Models;
using GlutenFreeApp.Resx;
using GlutenFreeApp.Services;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GlutenFreeApp.ViewModels
{
    public class MapViewModel : BaseViewModel
    {        
        private readonly ObservableCollection<MapPin> _ristoranti;
        private readonly RemoteRestaurantService remoteDb;
        public IEnumerable Ristoranti => _ristoranti;
        
        public MapViewModel()
        {
            Title = AppResources.StringMap;
            _ristoranti = new ObservableCollection<MapPin>();
            remoteDb = new RemoteRestaurantService();
            LoadPins();
        }

        private async void LoadPins()
        {
            LocalRestaurantService localDb = await LocalRestaurantService.Instance;

            try
            {
                var ristoranti = RestaurantFromQuery2RestaurantService.Convert(await remoteDb.GetRestaurantsAsync());
                foreach (var ristorante in ristoranti)
                {
                    this._ristoranti.Add(new MapPin(ristorante.Indirizzo, ristorante.Nome, ristorante.Posizione));
                    await localDb.AddRestaurantAsync(ristorante.ID, ristorante.Nome, ristorante.Indirizzo, ristorante.Citta,
                        ristorante.Provincia.Nome, ristorante.Regione.Nome, ristorante.Latitudine, ristorante.Longitudine,
                        ristorante.TipoCucina, ristorante.MenuAParte, ristorante.ImageId, ristorante.URL);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
