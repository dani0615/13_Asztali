using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehenek
{

   public class Tehen : IEquatable<Tehen>
    {

        public string Id { get; private set; }
        public int[] Mennyisegek { get; private set; }

        public bool Equals(Tehen masik)
        {
            return masik != null && masik.Id == this.Id;
        }

        public void EredmenytRogzit(string nap, string menyiseg)
        {
            Mennyisegek[int.Parse(nap)] = int.Parse(menyiseg);
        }

       

        public int HetiTej()
        {
            if (Mennyisegek == null ) return 0;

            int osszeg = 0;
            foreach (var mennyiseg in Mennyisegek)
            {
                osszeg += mennyiseg;
            }
            return osszeg;
        }

        public int hetiAtlag() 
        {
            double count = 0;

            foreach (var mennyiseg in Mennyisegek)
            {
                if (mennyiseg != 0)
                                    {
                    count++;
                }
            }
            if (count <= 3)
            {
                return (int)Math.Round(HetiTej() / count, 2);
            }
            else return -1;

        }







        public Tehen(string id)
        {
            Id = id;
            Mennyisegek = new int[7];
        }
    }
}
