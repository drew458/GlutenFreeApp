using Xamarin.Forms.Maps;

namespace GlutenFreeApp.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public Provincia Provincia { get; set; }
        public Regione Regione { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        public TipologieCucina TipoCucina { get; set; }
        public int MenuAParte { get; set; }
        public int ImageId { get; set; }
        public Position Posizione { get; set; }
    }
}
