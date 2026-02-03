using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutoversenyWPF
{
   public class Versenyzok
    {
        public int Rajtszam { get; set; }
        public string Nev { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public string Orszag { get; set; }
        public TimeSpan Eredmeny { get; set; }

        public int Eletkor 
        { 
            get 
            {
                return DateTime.Now.Year - SzuletesiDatum.Year;
            } 
        }

        public Versenyzok(string sor) 
        {
            var adatok = sor.Split(';');
            Rajtszam = int.Parse(adatok[0]);
            Nev = adatok[1];
            SzuletesiDatum = DateTime.Parse(adatok[2]);
            Orszag = adatok[3];
            Eredmeny = TimeSpan.Parse("0:" + adatok[4].Replace('.', ','));
        }
    }
}
