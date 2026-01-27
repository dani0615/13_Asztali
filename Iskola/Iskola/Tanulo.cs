using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Tanulo
    {
        public int KezdesiEv { get; private set; }
        public string Osztalybetujele { get; private set; }
        public string DiakNeve { get; private set; }

        public Tanulo(string sor) 
        {
            var adatok = sor.Split(';');
            KezdesiEv = int.Parse(adatok[0]);
            Osztalybetujele = adatok[1];
            DiakNeve = adatok[2];
        }

        public Tanulo(int kezdesiEv, string osztalybetujele, string diakNeve)
        {
            KezdesiEv = kezdesiEv;
            Osztalybetujele = osztalybetujele;
            DiakNeve = diakNeve;
        }

        //public string Azonosito
        //{
        //    get
        //    {
               
        //        string evfolyam = (KezdesiEv % 10).ToString();
        //        string osztaly = Osztalybetujele.ToLower();

               
        //        string[] nevReszek = DiakNeve.Split(' '); 
        //        string vezeteknev = nevReszek[0].ToLower().Substring(0, 3);
        //        string keresztnev = nevReszek[1].ToLower().Substring(0, 3);

        //        return evfolyam + osztaly + vezeteknev + keresztnev;
        //    }
        //}

        public string Azonosito() 
        {
            string jelszo = string.Empty;
            jelszo += (KezdesiEv%10).ToString();
            jelszo += Osztalybetujele.ToLower();
            var nevek = DiakNeve.Split(' ');
            jelszo += nevek[0].ToLower().Substring(0, 3);
            jelszo += nevek[1].ToLower().Substring(0, 3);
            return jelszo;


        }

        public override string? ToString()
        {
            return $"Kezdési év: {KezdesiEv}, Osztály Betűjele: {Osztalybetujele}, Név: {DiakNeve}";
        }
    }
}
