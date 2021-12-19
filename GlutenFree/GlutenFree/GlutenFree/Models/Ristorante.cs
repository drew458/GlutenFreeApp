using Xamarin.Forms.Maps;

namespace GlutenFree.Models
{
    public class Ristorante
    {
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public Position Posizione { get; set; }
        public int NumeroVie { get; internal set; }
        public int VieConRipetizioni { get; internal set; }
        public int NumeroRipetizioni { get; internal set; }
    }
}