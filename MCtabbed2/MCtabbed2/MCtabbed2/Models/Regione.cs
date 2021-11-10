using System.Collections.Generic;
using Xamarin.Forms;

namespace MCtabbed2.Models
{
    public class Regione
    {
        public string Nome { get; set; }
        public ImageSource Immagine { get; set; }
        public IList<Provincia> Province { get; set; }

    }
}
