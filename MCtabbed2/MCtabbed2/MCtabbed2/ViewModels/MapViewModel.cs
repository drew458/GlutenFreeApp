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

        private ObservableCollection<PinMappa> _luoghi;

        public IEnumerable Luoghi => _luoghi;


        public MapViewModel()
        {
            LoadPins();
        }

        private async void LoadPins()
        {
            IEnumerable<Regione> regioni = await DataStore.GetItemsAsync();
            IList<Provincia> province = new List<Provincia>();
            IList<Falesia> falesie = new List<Falesia>();
            _luoghi = new ObservableCollection<PinMappa>();

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

                            _luoghi.Add(new PinMappa(falesia.Indirizzo, falesia.Nome, falesia.Posizione));
                        }
                    }
                }
            }
            
        }
    }
}
