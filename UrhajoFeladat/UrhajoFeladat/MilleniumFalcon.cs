using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrhajoFeladat
{
    internal class MilleniumFalcon : IUrhajo, IHiperhajtomu
    {
        double tapasztalat;
        
        public MilleniumFalcon()
        {
            tapasztalat = 100;
        }


        public void HiperUgras()
        {
            tapasztalat += 500;
        }

        public bool LegyorsuljaE(IUrhajo Urhajo)
        {
            if (this.MilyenGyors() > Urhajo.MilyenGyors())
            {
                return true;
            }
            return false;


        }

        public double MilyenGyors()
        {
            return tapasztalat * 2;
        }

        public override string? ToString()
        {
            return $"Millenium Falcon, Sebessége: {MilyenGyors()}, Tapasztalat: {tapasztalat}";

        }
    }

}
