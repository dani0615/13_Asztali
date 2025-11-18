using System.Reflection.Metadata;

namespace Jarmuvek
{
    internal class Orszagut
    {
        static List<Jarmu> jarmuvek = new List<Jarmu>();
        static void Main(string[] args)
        {
            try
            {
                jarmuvekJonnek("C:\\Users\\haluskad\\source\\repos\\Jarmuvek\\Jarmuvek\\Jarmuvek.txt", "Jarmuvek.txt");
                kiketMertunkBe();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Hiba történt: {ex.Message}");
            }
        }

        static void jarmuvekJonnek(string path, string nev)
        {
            try
            {
                var sorok = File.ReadAllLines(path);
                foreach (var sor in sorok)
                {
                    var adatok = sor.Split(';');
                    try
                    {
                        if (adatok[0] == "robogo")
                        {
                            jarmuvek.Add(new Robogo(
                                int.Parse(adatok[2]),
                                adatok[1],
                                int.Parse(adatok[3])
                            ));
                        }
                        else if (adatok[0] == "audi")
                        {
                            jarmuvek.Add(new AudiS8(
                                int.Parse(adatok[2]),
                                adatok[1],
                                bool.Parse(adatok[3])
                            ));
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.Error.WriteLine($"Formátum hiba: {ex.Message} ({sor})");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Hiba: {ex.Message} ({sor})");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"I/O hiba: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Hiba: {ex.Message}");
            }
        }

        static void kiketMertunkBe()
        {
            try
            {
                var kimenet = new List<string>();
                foreach (var jarmu in jarmuvek)
                {
                    if (jarmu is AudiS8 audi)
                    {
                        kimenet.Add(audi.ToString() + (audi.GyorsanhajtottE(90) ? " Gyorsanhajtott" : " Nem gyorsanhajtott"));
                    }
                    else if (jarmu is Robogo robogo)
                    {
                        kimenet.Add(robogo.ToString() + (robogo.Haladhat(90) ? " Haladhat" : " Nem haladhat"));
                    }
                }
                File.WriteAllLines("buntetes.txt", kimenet);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"I/O hiba: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Hiba: {ex.Message}");
            }



           
        }
    }
}
