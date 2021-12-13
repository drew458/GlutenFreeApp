using MCtabbed2.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MCtabbed2.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        //alcuni pezzi presi da
        // https://github.com/xamarin/xamarin-forms-samples/blob/main/WorkingWithMaps/WorkingWithMaps/WorkingWithMaps/ViewModels/PinItemsSourcePageViewModel.cs

        private ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;


        public MapViewModel()
        {
            LoadPins();
        }

        private async void LoadPins()
        {
            IEnumerable<Regione> regioni = await DataStore.GetItemsAsync();
            IList<Provincia> province = new List<Provincia>();
            IList<Falesia> falesie = new List<Falesia>();
            _locations = new ObservableCollection<Location>();

            foreach (Regione regione in regioni)
            {
                foreach (Provincia provincia in regione.Province)
                {
                    province.Add(provincia);
                    if (provincia.Falesie != null)
                    {
                        foreach (Falesia falesia in provincia.Falesie)
                        {
                            falesie.Add(falesia);

                            _locations.Add(new Location(falesia.Indirizzo, falesia.Nome, falesia.Posizione));
                        }
                    }
                }
            }
            
        }
    }
}
