using System.Collections.Generic;
using GlutenFree.Shared.Models;

namespace GlutenFree.Models
{
    public class Provincia
    {
        public string Nome { get; set; }
        public IList<Restaurant> Falesie { get; set; }
    }
}
