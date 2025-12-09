using System.Text.RegularExpressions;

namespace Regex_1209
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.feladat : regex használata
            string input = "Aki korán kel , egész nap fáradt lesz.";

            string pattern = "korán";

            Regex rg = new Regex(pattern);

            Console.WriteLine(rg.IsMatch(input));

            // 2.feladat szavak kigyűjtése

            Console.WriteLine($"----------------------------------------");

            pattern = @"\b\w+\b";

            rg = new Regex(pattern);

            MatchCollection matches = rg.Matches(input);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }


            // 3.feladat : A k karakterrel kezdődő szavak
            Console.WriteLine("----------------------------------------");
            pattern = @"\b[k]\w+";

            rg = new Regex(pattern);

            matches = rg.Matches(input);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
                
            }

            // 4.Feladat : 

            Console.WriteLine("----------------------------------------");

            string mire = "későn";

            pattern = "korán";

            rg = new Regex(pattern);

            string newInput = rg.Replace(input, mire);

            Console.WriteLine(newInput);

            // 5.feladat space helyett kötőjel

            Console.WriteLine("----------------------------------------");

            string kotojel = "-";

            pattern = @"\s";

            rg = new Regex(pattern);

            string newInput2 = rg.Replace(input, kotojel);

            Console.WriteLine(newInput2);


            // 6.feladat daraboblás

            input = "alma körte    szilva\t\tbanán";
            pattern = @"\s+";

            rg = new Regex(pattern);
            string[] darabolt = rg.Split(input);
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }


            //7.feladat számok kigyűjtése
            input = "Ebben a szövegben 123, 222,54343 számok vannak";

            pattern = @"\b\d{3}\b";
            rg = new Regex(pattern);

            matches = rg.Matches(input);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }

        }
    }
}
