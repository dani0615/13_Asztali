using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UrhajoFeladat
{
    internal interface IUrhajo
    {
        ////LegyorsuljaE metódust tartalmaz. A metódus
        //paramétere egy IUrhajo objektum, és egy logikai értékkel tér vissza.Legyen
        //egy MilyenGyors metódusa is, ami nem kér paramétert, és az IUrhajo
        //gyorsaságát fogja visszaadni lebegőpontos formátumban.
        
        bool LegyorsuljaE(IUrhajo Urhajo);
        double MilyenGyors();


    }
}
