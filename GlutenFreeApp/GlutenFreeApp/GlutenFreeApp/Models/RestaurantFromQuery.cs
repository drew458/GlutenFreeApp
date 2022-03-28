using SQLite;

namespace GlutenFreeApp.Models
{
    public class RestaurantFromQuery
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Regione { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        public string TipoCucina { get; set; }
        public int MenuAParte { get; set; }
        public int ImageId { get; set; }
        public string URL { get; set; }
    }
}
