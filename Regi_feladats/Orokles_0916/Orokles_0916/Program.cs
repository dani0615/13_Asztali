using System.Runtime.InteropServices;

namespace Orokles_0916
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Alakzat a = new Alakzat(); //Az abszrakt osztályt nem lehet példányosítani.
            Kor kor = new Kor();
            kor.Rajzol();
            kor.Kiir();
            Ipelda interfaceTipus = kor;
            interfaceTipus.Kiir();
            kor.SetSzin();
            Console.WriteLine(kor.GetSzin());
            //---------------------------------
            Allat allat = new Allat();
            Macska macska = new Macska();
            Allat cat = new Macska();
            // Macska CAT = new Allat(); Nem működik , mert nem minden állat macska
            Console.WriteLine(allat);
            Console.WriteLine(macska);
            Console.WriteLine(cat);

            Kismacska kismacska = new Kismacska();
            Console.WriteLine(kismacska);

            Kutya kutya = new Kutya();
            Allat dog = new Allat();
            Console.WriteLine(kutya);
            Console.WriteLine(dog);



        }
    }
}
