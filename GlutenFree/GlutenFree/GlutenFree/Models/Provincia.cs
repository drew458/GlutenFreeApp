﻿using System.Collections.Generic;

namespace GlutenFree.Models
{
    public class Provincia
    {
        public string Nome { get; set; }
        public IList<Restaurant> Ristoranti { get; set; }
    }
}