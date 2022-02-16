using System.Collections.Generic;
using Xamarin.Forms;

namespace GlutenFreeApp.Models
{
    public class Regione
    {
        public string Nome { get; set; }
        public ImageSource Immagine { get; set; }
        public IList<Provincia> Province { get; set; }

    }
}
