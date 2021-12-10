using System.Collections.Generic;

namespace MCtabbed2.Models
{
    public class Provincia
    {
        public string Nome { get; set; }
        public IList<Falesia> Falesie { get; set; }
    }
}
