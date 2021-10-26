using System;
using System.Collections.Generic;
using System.Text;

namespace MCtabbed2.Models
{
    public class Regione
    {

        public string Nome { get; set; }
        public string Immagine { get; set; }

        public Regione(string Nome, string Immagine)
        {
            this.Nome = Nome;
            this.Immagine = Immagine;
        }
    }
}
