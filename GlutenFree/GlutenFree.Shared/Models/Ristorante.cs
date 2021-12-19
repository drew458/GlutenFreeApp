using Xamarin.Forms.Maps;

namespace MCtabbed2.Models
{
    public class Falesia
    {
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public int NumeroVie { get; set; }
        public int VieConRipetizioni { get; set; }
        public int NumeroRipetizioni { get; set; }
        public Position Posizione { get; set; }
    }
}