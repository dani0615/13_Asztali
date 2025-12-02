using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teszt2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt2.Tests
{
    [TestClass()]
    public class AlapTests
    {
        Alap alap = null;
        [TestInitialize]
        public void Setup() 
        {
            alap = new Alap();
        }



        [TestMethod()]
        [DataRow("alma",0,"Alma")]
        [DataRow("alma" , -1 , "alma")]
        [DataRow("alma",5 , "alma")]
        public void NagyBetuTest(string szoveg, int index , string elvart)
        {
            
            string eredmeny = alap.NagyBetu(szoveg, index);

            Assert.AreEqual(elvart, eredmeny);
        }

        [TestMethod()]
        [DataRow("alma" ,8)]
        [DataRow("g",-25)]
        [DataRow("",0)]
        public void NagyBetuOutOfRangeException(string szoveg , int index) 
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (
                () => alap.NagyBetu(szoveg,index)
                );
        }

    }
}