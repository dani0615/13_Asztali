using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiEszközök
{
    internal interface IKapcsolhato
    {
        bool Bekapcsolva { get; set; }
        void Bekapcsol();
        void Kikapcsol();
    }
}
