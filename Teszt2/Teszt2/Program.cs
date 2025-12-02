namespace Teszt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NagyBetuTest();
        }

        private static void NagyBetuTest()
        {
            Alap alap = new Alap();
            string eredmeny = alap.NagyBetu("hello vilag", 6);
            Console.WriteLine(eredmeny);
        }
    }
}
