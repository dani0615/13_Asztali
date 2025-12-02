using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt2
{
    public class Alap
    {

        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public Alap() 
        { }

        public Alap(string sor) 
        {
            string[] adatok = sor.Split(";");
            
        }
       
        public string NagyBetu(string szoveg , int index) 
        {
            char[] chars = szoveg.ToCharArray();
            if (index >= 0 && index < chars.Length)
            {
                chars[index] = char.ToUpper(chars[index]);
                string eredmeny = new string(chars);

            }
            else 
            {
                throw new ArgumentOutOfRangeException(index.ToString());
                
            }
                return new string(chars);
        }



    }
}
