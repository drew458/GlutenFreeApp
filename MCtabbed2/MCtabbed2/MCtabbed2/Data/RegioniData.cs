using System;
using System.Collections.Generic;
using System.Text;
using MCtabbed2.Models;
using Xamarin.Forms;

namespace MCtabbed2.Data
{
    class RegioniData
    {
        public static IList<Regione> Regioni { get; private set; }

        static RegioniData()
        {
            Regioni = new List<Regione>
            {
                new Regione
                {
                    Nome = "Abruzzo",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_abruzzo.png")
                },

                new Regione
                {
                    Nome = "Basilicata",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_basilicata.png")
                },

                new Regione
                {
                    Nome = "Calabria",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_calabria.png")
                },

                new Regione
                {
                    Nome = "Campania",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_campania.png")
                },

                new Regione
                {
                    Nome = "Emilia Romagna",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_emiliaromagna.png")
                },

                new Regione
                {
                    Nome = "Friuli Venezia Giulia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_friuli.png")
                },

                new Regione
                {
                    Nome = "Lazio",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_lazio.png")
                },

                new Regione
                {
                    Nome = "Liguria",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_liguria.png")
                },

                new Regione
                {
                    Nome = "Lombardia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_lombardia.png") 
                },

                new Regione
                {
                    Nome = "Marche",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_marche.png") 
                },

                new Regione
                {
                    Nome = "Molise",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_molise.png")
                },

                new Regione
                {
                    Nome = "Piemonte",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_piemonte.png")
                },

                new Regione
                {
                    Nome = "Puglia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_puglia.png")
                },

                new Regione
                {
                    Nome = "Sardegna",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_sardegna.png")
                },

                new Regione
                {
                    Nome = "Sicilia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_sicilia.png")
                },

                new Regione
                {
                    Nome = "Toscana",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_toscana.png")
                },

                new Regione
                {
                    Nome = "Trentino Alto Adige",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_trentino.png")
                },

                new Regione
                {
                    Nome = "Umbria",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_umbria.png")
                },

                new Regione
                {
                    Nome = "Valle d'Aosta",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_valleaosta.png")
                },

                new Regione
                {
                    Nome = "Veneto",
                    Immagine = ImageSource.FromResource("MCtabbed2.Images.flag_veneto.png")
                }
            };
        }

    }
}
