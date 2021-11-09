using System;
using System.Collections.Generic;
using System.Text;
using MCtabbed2.Models;
using Xamarin.Forms;

namespace MCtabbed2.Data
{
    class ProvinceData
    {
        public static IList<Provincia> Province { get; private set; }

        // TODO: popolare la lista facendo binding da database
        static ProvinceData()
        {
            Province = new List<Provincia>();
        }

    }
}
