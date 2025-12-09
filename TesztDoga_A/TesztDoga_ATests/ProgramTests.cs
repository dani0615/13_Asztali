using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesztDoga_A;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztDoga_A.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        [DataRow("1010" , 10)]
        [DataRow("0", int.MaxValue)]
        [DataRow("0" , 0)]
        [DataRow("11111111111111111111111111111111" , -1)]
        public void DecToBinTest(string exp , int act)
        {
            Assert.AreEqual(exp, Program.DecToBin(act));
        }


        [TestMethod()]
        public void DecToBinExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => Program.DecToBin(int.MinValue+1));
        }

        [TestMethod()]

        public void DecToBinBetuTest()
        {
            Assert.ThrowsException<FormatException>(() => Program.DecToBin(int.Parse("abc")));
        }

        [TestMethod()]

        public void DecToBinOverflowTest()
        {
            Assert.ThrowsException<OverflowException>(() => Program.DecToBin(int.Parse("9999999999999999999999999")));
        }
    }
}
