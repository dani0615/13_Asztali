using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles_0916
{
    internal class Kor : Alakzat, Ipelda, Ipelda1
    {
        public Kor()
        {
        }

        //alapértelmezett az Ipelda1
        public void Kiir()
        {
            Console.WriteLine("Interface");
        }
        //explicit módon meg kell adni az Interface-t
        //a metódus csak private lehet
        void Ipelda.Kiir()
        {
            Console.WriteLine("Ipelda1");
        }
        public override void Rajzol()//Kötelező felüldefiniálni
        {
            Console.WriteLine("A kör kirajzolása");
        }

        public override void SetSzin()
        {
            Szin = "Zöld";
        }

    }
}
