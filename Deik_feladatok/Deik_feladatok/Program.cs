using System;
using System.Text;
namespace Deik_feladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] units = input.Split(' ');
            StringBuilder result = new StringBuilder();

            foreach (string unit in units)
            {
                if (unit == "nl")
                {
                    result.Append('\n');
                }
                else if (unit.EndsWith("sp"))
                {
                    int count = int.Parse(unit.Substring(0, unit.Length - 2));
                    result.Append(' ', count);
                }
                else if (unit.EndsWith("bS"))
                {
                    int count = int.Parse(unit.Substring(0, unit.Length - 2));
                    result.Append('\\', count);
                }
                else if (unit.EndsWith("sQ"))
                {
                    int count = int.Parse(unit.Substring(0, unit.Length - 2));
                    result.Append('\'', count);
                }
                else
                {
                    // n(char) formátum
                    int i = 0;
                    while (i < unit.Length && char.IsDigit(unit[i]))
                    {
                        i++;
                    }
                    int count = int.Parse(unit.Substring(0, i));
                    string character = unit.Substring(i);

                    for (int j = 0; j < count; j++)
                    {
                        result.Append(character);
                    }
                }
            }

            Console.Write(result.ToString());


        }
    }
}