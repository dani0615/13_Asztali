using System;
using System.Globalization;

namespace LOLV4
{
    public class Hos
    {
        
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string Tag { get; private set; }
        public double HP { get; private set; }
        public double AttackDamage { get; private set; }
        public double AttackDamagePerLevel { get; private set; }

        
        public Hos(string sor)
        {
           
            var parts = sor.Split(';');
            Name = parts[0];
            Title = parts[1];
            Category = parts[2];
            Tag = parts[3];
            HP = double.Parse(parts[4]);
            AttackDamage = double.Parse(parts[5]);
            AttackDamagePerLevel = double.Parse(parts[6]);
        }

        
        public double ADLevel(int szint)
        {
            if (szint < 1 || szint > 18) return -1;
            return AttackDamage + (szint - 1) * AttackDamagePerLevel;
        }

        public override string? ToString()
        {
            return $"{Name};{Title};{Category};{Tag};{HP};{AttackDamage};{AttackDamagePerLevel}";
        }
    }
}
