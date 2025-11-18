using System;

namespace ElektronikaiEszközök
{
    internal class Zseblámpa : IKapcsolhato
    {
        public bool Bekapcsolva { get; set; }

        public Zseblámpa()
        {
            Bekapcsolva = false; 
        }

        public void Bekapcsol()
        {
            Bekapcsolva = true;
            Console.WriteLine("A zseblámpa be van kapcsolva.");
        }

        public void Kikapcsol()
        {
            Bekapcsolva = false;
            Console.WriteLine("A zseblámpa ki van kapcsolva.");
        }
    }
}