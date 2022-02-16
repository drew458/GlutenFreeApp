﻿using System.ComponentModel;
using Xamarin.Forms.Maps;

namespace GlutenFreeApp.Models
{
    public class MapPin : INotifyPropertyChanged
    {
        // preso da https://github.com/xamarin/xamarin-forms-samples/blob/main/WorkingWithMaps/WorkingWithMaps/WorkingWithMaps/ViewModels/Location.cs

        private Position _posizione;

        public string Indirizzo { get; }
        public string Descrizione { get; }

        public Position Posizione
        {
            get => _posizione;
            set
            {
                if (!_posizione.Equals(value))
                {
                    _posizione = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Posizione)));
                }
            }
        }

        public MapPin(string indirizzo, string descrizione, Position posizione)
        {
            Indirizzo = indirizzo;
            Descrizione = descrizione;
            Posizione = posizione;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
