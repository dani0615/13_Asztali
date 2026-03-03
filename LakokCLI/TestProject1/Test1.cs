using LakokCLI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TartozikTest()
        {
            Lakas l = new Lakas("Miskolc, Kuruc utca 52 1/1,3,Kiss Istvánné,60,100");
            Assert.IsTrue(l.Tartozik());

            Lakas l1 = new Lakas("Miskolc, Kuruc utca 52 1/1,3,Kiss Istvánné,60,0");
            Assert.IsFalse(l1.Tartozik());
        }

        [TestMethod]
        public void TulzsufoltE() 
        {
            Lakas l = new Lakas("Miskolc, Kuruc utca 52 3/3,5,Kiss Istvánné,56,100");
            Assert.IsTrue(l.Tulzsufolt());
            Lakas l1 = new Lakas("Miskolc, Kuruc utca 52 1/1,3,Kiss Istvánné,60,0");
            Assert.IsFalse(l1.Tulzsufolt());
        }
    }
}
