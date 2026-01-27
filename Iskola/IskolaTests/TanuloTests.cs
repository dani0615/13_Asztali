using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola.Tests
{
    [TestClass()]
    public class TanuloTests
    {
        
        [TestMethod]
        [DataRow("2006;c;Bodnar Szilvia", "6cbodszi")]
        [DataRow("2005;b;Kovacs Orsolya", "5bkovors")]
        
        public void Azonosito_Pozitiv(string alapadat , string jelszo)
        {
            Tanulo tanulo = new Tanulo(alapadat);
            string actual = tanulo.Azonosito();

            Assert.AreEqual(jelszo, actual);
        }

        [TestMethod]
        [DataRow("2006;c;Bodnar Szilvia", "6cBodSzi")]
        [DataRow("2005;b;Kovacs Orsolya", "050bkovors")]
        
        public void Azonosito_Negativ(string alapadat, string jelszo)
        {
            Tanulo tanulo = new Tanulo(alapadat);
            string actual = tanulo.Azonosito();

            Assert.AreNotEqual(jelszo, actual);
        }





    }
}