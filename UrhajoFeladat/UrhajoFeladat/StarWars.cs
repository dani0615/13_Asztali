using System.Net.NetworkInformation;

namespace UrhajoFeladat
{
    internal class StarWars
    {
        static List<IUrhajo> urhajok = new List<IUrhajo>();
        static void Main(string[] args)
        {
            Urhajok("Urhajok.txt");
            hangar();
            Leggyorsabb();
            Feladat8();
            Feladat9();
            Feladat10();
            
            
        }
        // 10. Határozza meg, hogy van-e olyan MilleniumFalcon amit legyorsul valamelyik Xwing ha van, akkor írja ki az adott Falconokat adataival, majd alá az   XWingeket az adataival.

        private static void Feladat10()
        {
            List<MilleniumFalcon> falconok = new List<MilleniumFalcon>();
            List<XWing> xwingek = new List<XWing>();
            foreach (var item in urhajok)
            {
                if(item is MilleniumFalcon)
                {
                    falconok.Add(item as MilleniumFalcon);
                }
                else if (item is XWing)
                {
                    xwingek.Add(item as XWing);
                }
            }
            foreach (var falcon in falconok)
            {
                foreach (var xwing in xwingek)
                {
                    if (xwing.LegyorsuljaE(falcon))
                    {
                        Console.WriteLine(falcon.ToString());
                        Console.WriteLine("\t"+xwing.ToString());
                    }
                }
            }


        }

        private static void Feladat9()
        {
            int db =0;
            foreach (var item in urhajok)
            {
                if (item is XWing && (item as XWing).ElkapjaAVonosugar()) 
                {
                    db++;
                }
            }
            Console.WriteLine($"A vonósugár {db} db gépet kap el.");
           
        }

        static void Urhajok(string path)
        {
            string[] sorok = File.ReadAllLines(path); 
            foreach (var sor in sorok)
            {
                string[] adatok = sor.Split(" ");
                string tipus = adatok[0];
                int ugrasokSzama = int.Parse(adatok[1]);
                if (tipus == "XWing")
                {
                    XWing xwing = new XWing();
                    for (int i = 0; i < ugrasokSzama; i++)
                    {
                        xwing.HiperUgras();
                    }
                    urhajok.Add(xwing);
                }
                else if (tipus == "MilleniumFalcon")
                {
                    MilleniumFalcon millenium = new MilleniumFalcon();
                    for (int i = 0; i < ugrasokSzama; i++)
                    {
                        millenium.HiperUgras();
                    }
                    urhajok .Add(millenium);
                }

            }

        }

        static void hangar()
        {
            try
            {
                foreach (var urh in urhajok)
                {
                    Console.WriteLine(urh.ToString());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Hiba tortent a fajl kezeles soran: " + ex.Message);

            }
        }

        // Határozza meg a leggyorsabb XWing és Falcon űrhajókat, majd írja ki az adatait.
        static void Leggyorsabb()
        {
            int mfStart=0 , xwStart=0;//kezdő indexek
            while (mfStart < urhajok.Count && urhajok[mfStart] is not MilleniumFalcon)
            {
                mfStart++;
            }
            while (xwStart < urhajok.Count && urhajok[xwStart] is not XWing)
            {
                xwStart++;
            }
            
            {
                for (int i = mfStart; i < urhajok.Count; i++)
                {
                    if (urhajok[i] is MilleniumFalcon)
                        if (urhajok[i].LegyorsuljaE(urhajok[mfStart]))
                    {
                        mfStart = i;
                    }
                }
            }
           

            for(int i = xwStart;i < urhajok.Count; i++)
            {
                if (urhajok[i]is XWing)
                    if (urhajok[i].LegyorsuljaE(urhajok[xwStart]))
                    {
                        xwStart = i;
                    }
            }
            

        }

        // 8. Válassza ki a lista első XWing és Falcon űrhajókat és határozza meg a győztest.
        static void Feladat8()
        {
            int mfStart = 0, xwStart = 0;//kezdő indexek
            while (mfStart < urhajok.Count && urhajok[mfStart] is not MilleniumFalcon)
            {
                mfStart++;
            }
            while (xwStart < urhajok.Count && urhajok[xwStart] is not XWing)
            {
                xwStart++;
            }
            if (urhajok[mfStart].LegyorsuljaE(urhajok[xwStart])) 
            {
                Console.WriteLine("A Millenium Falcon gyorsabb");
            }
            else
            {
                Console.WriteLine("Az X-Wing gyorsabb");
            }



        }
        
        


    }
}
