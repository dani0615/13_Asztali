using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszteles_11_25
{
    public class Matematika
    {
        public int Negyzet(int a) 
        {
            return a * a;
        }

        public double Osztas(double a, double b) 
        {
            return a / b;
        }


        public int Abetuszama(string szoveg) 
        {
            int db = 0;
            
            if (szoveg == null) 
            {
                db = 0;
               return db;
            }

            foreach (char c in szoveg) 
            {
                if (c == 'A' || c == 'a') 
                {
                    db++;
                }
            }
            return db;

           

        }

        public bool isParos(int a) 
        {
            if (a % 2 == 0) 
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
