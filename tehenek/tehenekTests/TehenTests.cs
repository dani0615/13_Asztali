using Microsoft.VisualStudio.TestTools.UnitTesting;
using tehenek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehenek.Tests
{
   

    [TestClass()]
    public class TehenTests
    {
        [TestMethod()]
        public void hetiAtlagTest()
        {
            Tehen t = new Tehen("Gizda");
            t.EredmenytRogzit("3", "100");
            t.EredmenytRogzit("5", "75");
            t.EredmenytRogzit("1", "100");
            Assert.AreEqual(91, t.hetiAtlag());
        }
    }
}