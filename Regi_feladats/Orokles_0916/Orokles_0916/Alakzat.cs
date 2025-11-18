using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles_0916
{
    internal abstract class Alakzat
    {
        protected string Szin;

        public virtual void SetSzin()
        {
            Szin = "Fehér";
        }
        public string GetSzin()
        {
            return Szin;
        }
        public abstract void Rajzol(); //Nem adunk meg törzset


    }
}
