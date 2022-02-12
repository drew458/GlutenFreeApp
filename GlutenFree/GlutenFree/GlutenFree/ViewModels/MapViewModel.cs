﻿using GlutenFree.Models;
using GlutenFree.Resx;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GlutenFree.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        //alcuni pezzi presi da
        // https://github.com/xamarin/xamarin-forms-samples/blob/main/WorkingWithMaps/WorkingWithMaps/WorkingWithMaps/ViewModels/PinItemsSourcePageViewModel.cs

        private ObservableCollection<MapPin> _luoghi;

        public IEnumerable Luoghi => _luoghi;


        public MapViewModel()
        {
            Title = AppResources.StringMap;
            LoadPins();
        }

        private async void LoadPins()
        {
            IEnumerable<Regione> regioni = await DataStore.GetItemsAsync();
            IList<Provincia> province = new List<Provincia>();
            IList<Restaurant> ristoranti = new List<Restaurant>();
            _luoghi = new ObservableCollection<MapPin>();

            foreach (Regione regione in regioni)
            {
                foreach (Provincia provincia in regione.Province)
                {
                    province.Add(provincia);
                    if (provincia.Ristoranti != null)
                    {
                        foreach (Restaurant Restaurant in provincia.Ristoranti)
                        {
                            ristoranti.Add(Restaurant);

                            _luoghi.Add(new MapPin(Restaurant.Indirizzo, Restaurant.Nome, Restaurant.Posizione));
                        }
                    }
                }
            }
            
        }
    }
}