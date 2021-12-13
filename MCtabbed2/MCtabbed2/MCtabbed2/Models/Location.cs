using System.ComponentModel;
using Xamarin.Forms.Maps;

namespace MCtabbed2.Models
{
    public class Location : INotifyPropertyChanged
    {
        // preso da https://github.com/xamarin/xamarin-forms-samples/blob/main/WorkingWithMaps/WorkingWithMaps/WorkingWithMaps/ViewModels/Location.cs

        private Position _position;

        public string Address { get; }
        public string Description { get; }

        public Position Position
        {
            get => _position;
            set
            {
                if (!_position.Equals(value))
                {
                    _position = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
                }
            }
        }

        public Location(string address, string description, Position position)
        {
            Address = address;
            Description = description;
            Position = position;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
