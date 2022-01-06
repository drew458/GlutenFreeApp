
namespace GlutenFree.Models
{
    public class TipologieCucina
    {
        public int Id { get; set; }
        public int IdTipoCucina { get; set; }
        public string Principale { get; set; }
        public string Secondaria { get; set; }
        public string Terziaria { get; set; }
    }
}
