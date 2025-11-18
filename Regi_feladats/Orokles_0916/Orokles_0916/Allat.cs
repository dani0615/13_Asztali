using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles_0916
{
    internal class Allat
    {
        protected string beszede;

        public virtual void Beszel()
        {
            beszede = string.Empty;
        }

        public string GetBeszed()
        {
            Beszel();
            return beszede;
        }

        public override string? ToString()
        {
            return $"Az állat beszéde: {GetBeszed()}";
        }
    }
}
