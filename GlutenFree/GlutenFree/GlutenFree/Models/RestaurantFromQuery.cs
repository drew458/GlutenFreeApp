namespace GlutenFree.Models
{
    public class RestaurantFromQuery
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Regione { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        public int IdTipoCucina { get; set; }
        public int MenuAParte { get; set; }
        public int ImageId { get; set; }
    }
}
