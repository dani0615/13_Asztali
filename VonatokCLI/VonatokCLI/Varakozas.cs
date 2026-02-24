using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VonatokCLI
{
    public class Varakozas
    {
        public Varakozas(string allomas, string erkezo, string indulo, int varakozasIdo, string vonal)
        {
            Allomas = allomas;
            Erkezo = erkezo;
            Indulo = indulo;
            VarakozasIdo = varakozasIdo;
            Vonal = vonal;
        }
        public Varakozas()
        { }


        public Varakozas(string sor) 
        {
            string[] adatok = sor.Split("\t");
            Vonal = adatok[0];
            Allomas = adatok[1];
            Erkezo = adatok[2];
            Indulo = adatok[3];
            VarakozasIdo = int.Parse(adatok[4]);
        }

        [JsonPropertyName("allomas")]
        public string Allomas { get; set; }
        
        public string Erkezo { get; set; }
        public string Indulo { get; set; }
        public int VarakozasIdo { get; set; }
        public string Vonal { get; set; }

        public override string? ToString()
        {
            return $"Vonal: {Vonal} Állomás :{Allomas} "
                +$"\nÉrkező: {Erkezo}"
                +$"\nInduló: {Indulo}"
                +$"\nMaximális várakozási idő :{VarakozasIdo} perc";
        }

        public bool VarakozikE()
        { 
            if (VarakozasIdo > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
