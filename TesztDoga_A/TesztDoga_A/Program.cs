
namespace TesztDoga_A
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérek egy decimális számot");
            int dec = int.Parse(Console.ReadLine());
            DecToBin(dec);
        }



        public static string DecToBin(int dec)
        {
            string binary = Convert.ToString(dec, 2);
            Console.WriteLine(binary);
            return binary;

        }
    }
}

           
        
