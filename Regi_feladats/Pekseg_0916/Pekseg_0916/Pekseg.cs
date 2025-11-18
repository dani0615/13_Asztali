namespace Pekseg_0916
{
    internal class Pekseg
    {
        static List<IArlap> termekek = new List<IArlap>();
        static void Main(string[] args)
        {
            try
            {
                Vasarlok("", "");
                etelLeltar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a program futása során: {ex.Message}");
            }
        }
        static void Vasarlok(string path, string fileName)
        {
            try
            {
                string[] allomany = File.ReadAllLines(path + fileName);

                foreach (var sor in allomany)
                {
                    if (sor.Split(" ")[0] == "Kave")
                    {
                        bool habos = sor.Split(" ")[1] == "habos" ? true : false;
                        termekek.Add(new Kave(habos));
                    }
                    else
                    {
                        termekek.Add(new Pogacsa(double.Parse(sor.Split(" ")[1]), double.Parse(sor.Split(" ")[2])));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a feldolgozás során:{ex.Message}");
            }
            
        }

        static void etelLeltar()
        {
            try
            {
                double osszErtek = 0;
                int db = 0;
                using (StreamWriter sw = new StreamWriter("leltar.txt"))
                {
                    foreach (var item in termekek)
                    {
                        if (item is Pogacsa)
                        {
                            sw.WriteLine(item.ToString());
                            osszErtek += item.MennyibeKerul();
                            db++;
                        }
                    }
                }
                Console.WriteLine($"Összesen {db} db tétel van, értékük {osszErtek} Ft");
            }
            catch (IOException ioex)
            {
                Console.WriteLine($"Fájl írási hiba: {ioex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a leltár készítése során: {ex.Message}");
            }
        }   
    }
    }

