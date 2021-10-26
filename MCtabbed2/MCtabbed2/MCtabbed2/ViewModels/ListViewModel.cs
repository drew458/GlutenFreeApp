using MCtabbed2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCtabbed2.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public List<Regione> Regioni { get; set; }

        public ListViewModel()
        {
            Title = "Lista (regioni)";

            var immagine = "";

            Regioni = new List<Regione>();
            CreaCollezioneRegioni();
            
        }

        void CreaCollezioneRegioni()
        {
            {
                Regioni.Add(new Regione(
                    "Abruzzo", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Flag_of_Abruzzo.svg/640px-Flag_of_Abruzzo.svg.png"));
                Regioni.Add(new Regione(
                    "Basilicata", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Flag_of_Basilicata.svg/640px-Flag_of_Basilicata.svg.png"));
                Regioni.Add(new Regione(
                    "Calabria", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8b/Flag_of_Calabria.svg/640px-Flag_of_Calabria.svg.png"));
                Regioni.Add(new Regione(
                    "Campania", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Flag_of_Campania.svg/640px-Flag_of_Campania.svg.png"));
                Regioni.Add(new Regione(
                    "Emilia Romagna", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/77/Flag_of_Emilia-Romagna_%28de_facto%29.svg/640px-Flag_of_Emilia-Romagna_%28de_facto%29.svg.png"));
                Regioni.Add(new Regione(
                    "Friuli Venezia Giulia", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Flag_of_Friuli-Venezia_Giulia.svg/640px-Flag_of_Friuli-Venezia_Giulia.svg.png"));
                Regioni.Add(new Regione(
                    "Lazio", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e1/Flag_of_Lazio.svg/640px-Flag_of_Lazio.svg.png"));
                Regioni.Add(new Regione(
                    "Liguria", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Flag_of_Liguria.svg/640px-Flag_of_Liguria.svg.png"));
                Regioni.Add(new Regione(
                    "Lombardia", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Flag_of_Lombardy.svg/640px-Flag_of_Lombardy.svg.png"));
                Regioni.Add(new Regione(
                    "Marche", "https://upload.wikimedia.org/wikipedia/commons/0/07/Flag_of_Marche.svg"));
                Regioni.Add(new Regione(
                    "Molise", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Flag_of_Molise.svg/640px-Flag_of_Molise.svg.png"));
                Regioni.Add(new Regione(
                    "Piemonte", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Flag_of_Piedmont.svg/640px-Flag_of_Piedmont.svg.png"));
                Regioni.Add(new Regione(
                    "Puglia", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Flag_of_Apulia.svg/640px-Flag_of_Apulia.svg.png"));
                Regioni.Add(new Regione(
                    "Sardegna", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Flag_of_Sardinia%2C_Italy.svg/640px-Flag_of_Sardinia%2C_Italy.svg.png"));
                Regioni.Add(new Regione(
                    "Sicilia", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Sicilian_Flag.svg/640px-Sicilian_Flag.svg.png"));
                Regioni.Add(new Regione(
                    "Toscana", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Flag_of_Tuscany.svg/640px-Flag_of_Tuscany.svg.png"));
                Regioni.Add(new Regione(
                    "Trentino Alto Adige", "https://upload.wikimedia.org/wikipedia/commons/7/7f/Flag_of_Trentino-South_Tyrol.svg"));
                Regioni.Add(new Regione(
                    "Umbria", "https://upload.wikimedia.org/wikipedia/commons/c/cc/Flag_of_Umbria.svg"));
                Regioni.Add(new Regione(
                    "Valle d'Aosta", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Flag_of_Valle_d%27Aosta.svg/640px-Flag_of_Valle_d%27Aosta.svg.png"));
                Regioni.Add(new Regione(
                    "Veneto", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Flag_of_Veneto.svg/640px-Flag_of_Veneto.svg.png"));
            };
        }
    }
}
