using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using negyszogCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negyszogCLI.Tests
{
    [TestClass()]
    public class NegyszogTests
    {
        [TestMethod()]
        public void LeghosszabbOldalTest()
        {
            Negyszog n1 = new Negyszog("1 1 1 4");
            Assert.IsFalse(n1.LeghosszabbOldal());

        }

        [TestMethod()]

        public void ParalelogrammaETest() 
        {
            Negyszog n2 = new Negyszog("6 8 6 8");
            Assert.IsTrue(Program.ParalelogrammaE(n2));
        }

        [TestMethod()]
        public void RombuszETest() 
        {
            Negyszog n3 = new Negyszog("5 5 5 5");
            Assert.IsTrue(Program.RombuszE(n3));
        }
    }
}