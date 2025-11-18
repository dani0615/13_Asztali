using System;

namespace ElektronikaiEszközök
{
    internal class Telefon : IKapcsolhato, IToltheto
    {
        public bool Bekapcsolva { get; set; }
        public int ToltottsagiSzint { get; set; }

        public Telefon()
        {
            ToltottsagiSzint = 50; 
            Bekapcsolva = false; 
        }

        public void Bekapcsol()
        {
            if (ToltottsagiSzint > 0)
            {
                Bekapcsolva = true;
                Console.WriteLine("A telefon be van kapcsolva.");
            }
            else
            {
                Console.WriteLine("A telefon nem kapcsolható be, mert a töltöttségi szint nulla.");
            }
        }

        public void Kikapcsol()
        {
            Bekapcsolva = false;
            Console.WriteLine("A telefon ki van kapcsolva.");
        }

        public void Toltes(int mennyiseg)
        {
            ToltottsagiSzint += mennyiseg;
            if (ToltottsagiSzint > 100)
            {
                ToltottsagiSzint = 100; 
            }
            else if (ToltottsagiSzint < 0)
            {
                ToltottsagiSzint = 0;
            }
            Console.WriteLine($"A telefon töltöttségi szintje most {ToltottsagiSzint}%.");
        }
    }
}