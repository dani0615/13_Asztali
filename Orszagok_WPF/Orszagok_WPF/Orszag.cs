using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Orszagok_WPF
{
    public class Orszag
    {
        public string Orszagnev { get; set; }
        public int Nepesseg { get; set; }
        public string Kontinens { get; set; }

     

        public Orszag(string orszagnev, int nepesseg, string kontinens)
        {
            Orszagnev = orszagnev;
            Nepesseg = nepesseg;
            Kontinens = kontinens;
        }

    }
}
