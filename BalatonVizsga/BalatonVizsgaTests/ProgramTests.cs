using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonVizsga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonVizsga.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [DataRow("A" , 100 , 80000)]
        public void AdoTest(string adosav, int terulet, int eredmeny)
        {
           Assert.AreEqual(eredmeny, Program.Ado(adosav, terulet));
        }
    }
}