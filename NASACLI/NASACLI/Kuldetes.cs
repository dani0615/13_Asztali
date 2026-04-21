using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASACLI
{
    public class Kuldetes
    {
        public string Nev { get; private set; }

        
        public int Ev { get; private set; }
        public string Celpont { get; private set; }
        public int Legenyseg { get; private set; }
        public bool Sikeres { get; private set; }
        public string Leiras { get; private set; }
        public double Koltseg { get; private set; }
        public double HasznosTeher { get; private set; }

        public Kuldetes(string sor)
        {
            string[] darabok = sor.Split(';');
            Nev = darabok[0];
            Ev = int.Parse(darabok[1]);
            Celpont = darabok[2];
            Legenyseg = int.Parse(darabok[3]);
            Sikeres = darabok[4] == "Igen" ? true : false ;
            Leiras = darabok[5];
            Koltseg = double.Parse(darabok[6]);
            HasznosTeher = double.Parse(darabok[7]);
        }

        public string KockazatiSzint()
        {
            bool draga = Koltseg > 1;
            bool nehez = HasznosTeher > 10000;

            if (draga && nehez) return "Magas";
            if (draga || nehez) return "Közepes";
            return "Alacsony";
        }
    }
}
