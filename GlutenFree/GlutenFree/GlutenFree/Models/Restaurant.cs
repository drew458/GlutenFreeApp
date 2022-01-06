using Xamarin.Forms.Maps;

namespace GlutenFree.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public Provincia Provincia { get; set; }
        public Regione Regione { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        public string TipoCucina { get; set; }
        public bool MenuAParte { get; set; }
        public int ImageId { get; set; }
        public Position Posizione { get; set; }
    }
}