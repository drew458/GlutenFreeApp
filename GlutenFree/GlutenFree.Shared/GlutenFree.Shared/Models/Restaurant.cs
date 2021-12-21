using Xamarin.Forms.Maps;

namespace GlutenFree.Shared.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public Position Posizione { get; set; }
        public int NumeroVie { get; set; }
        public int VieConRipetizioni { get; set; }
        public int NumeroRipetizioni { get; set; }
    }
}