using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UrhajoFeladat
{
    internal class XWing : LazadoGep, IHiperhajtomu
    {
        public XWing() : base(150, true)
        {
        }

        //Az X-Wing et akkor kapja el a vonósugár, ha meghibásodhat, és
        //sebessége kisebb, mint 1000.
        public override bool ElkapjaAVonosugar()
        {
            if (this.MeghibasodhatE && MilyenGyors() < 1000)
            {
                return true;
            }
            return false;

        }
       // Ha az X-Wing hiperugrást végez, akkor sebessége egy 0-100 közötti
       //véletlenszerű lebegőpontos számmal nő.
        public void HiperUgras()
        {
           Random rnd = new Random();
           this.Sebesseg += rnd.NextDouble() * 100;

        }

        

        public override string? ToString()
        {
            return $"Az X-Wing sebessége : {MilyenGyors()}, {(MeghibasodhatE ? " meghibásodhat" : " nem hibásodik meg ")}.";
        }
    }
}
