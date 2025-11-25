using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teszteles_11_25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;

namespace Teszteles_11_25.Tests
{
    [TestClass()]

    public class MatematikaTests
    {
        private Matematika m;
        [TestInitialize]
        public void Setup()
        {
            m = new Matematika();
        }

        [TestCleanup]
        public void Cleanup()
        {
            m = null;
        }



        [TestMethod()]
        [DataRow(5)]
        [DataRow(0)]
        [DataRow(-4)]
        [DataRow(int.MaxValue)]

        public void NegyzetTest(int adat)
        {

            // Act
            int actualEredmeny = m.Negyzet(adat);

            // Assert 
            long varhatoEredmeny = (long)adat * adat;

            Assert.AreEqual(varhatoEredmeny, actualEredmeny);
        }

        [TestMethod()]
        [DataRow(5, 2)]

        public void OsztasTest(int a, int b)
        {
            double expected = (double)a / b;

            double act = m.Osztas(a, b);
            Assert.AreEqual(expected, act);

        }

        [TestMethod()]
        [DataRow(5, 0)]
        public void OsztasTest_DivideByZero(int a, int b)
        {
            Assert.Throws<DivideByZeroException>(() => m.Osztas(a, b));
        }

        [TestMethod()]
        [DataRow("Alma", 2)]        
        [DataRow("Ananász", 2)]
        [DataRow("Körte", 0)]
        [DataRow("",0)]
        public void AbetuszamaTest(string szoveg, int elvartDb)
        {
           
            int actualDb = m.Abetuszama(szoveg);

            
            Assert.AreEqual(elvartDb, actualDb);

        }


        [TestMethod()]
        [DataRow(null)]
        public void AbetuNUllTest(string a) { 
         
           Assert.Throws<NullReferenceException>(() => m.Abetuszama(a));
        }

        [TestMethod()]
        [DataRow(4, true)]
        public void ParosETrueTest(int a, bool elvart)
        {
            bool actual = m.isParos(a);
            Assert.AreEqual(elvart, actual);
        }

        [TestMethod()]
        [DataRow(5, false)]
        public void ParosEFalseTest(int a, bool elvart)
        {
            bool actual = m.isParos(a);
            Assert.AreEqual(elvart, actual);
        }


    }
}