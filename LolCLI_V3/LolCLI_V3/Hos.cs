using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolCLI_V3
{
    public class Hos
    {
        public string Name { get; private set; }

        public string Title { get; private set; }

        public  string Category { get; private set; }

        public double HP { get; private set; }

        public double MoveSpeed { get; private set; }
        public double Armor { get; private set; }

        public Hos (string sor) 
        {
            string[] adatok = sor.Split(";");
            Name = adatok[0];
            Title = adatok[1];
            Category = adatok[2];
            HP = double.Parse(adatok[3]);
            MoveSpeed = double.Parse(adatok[4]);
            Armor = double.Parse(adatok[5]);
        }
        
        public double ArmorLevel(int szint) 
        {
            if (szint < 1 || szint > 18) return 1.0;
            switch (Category)
            {
                case"Fighter":
                        return Armor+20*szint;
                case "Mage":
                    return Armor+15*szint;
                case "Assassin":
                    return Armor+18*szint;
                case "Tank":
                    return Armor+40*szint;
                case"Marksman":
                    return Armor+10*szint;
                case "Support":
                    return Armor+30*szint;
                default:
                    return 1.0;
                   
            }

        }
    }
}
