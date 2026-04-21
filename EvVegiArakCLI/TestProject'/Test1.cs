using ArakCLI;

namespace TestProject_
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void ValtozasPozitiv()
        {
            
            Arak arak = new Arak("10001\tRövidkaraj\t2610\t2630");
            Assert.AreEqual(20, arak.Valtozas());
        }

        [TestMethod]
        public void ValtozasNegativ()
        {
            
            Arak arak = new Arak("10103\tMarhahús\t4560\t4480");
            Assert.AreEqual(-80, arak.Valtozas());
        }

        [TestMethod]
        public void ValtozasNulla()
        {
           
            Arak arak = new Arak("99999\tTeszt termék\t1000\t1000");
            Assert.AreEqual(0, arak.Valtozas());
        }
    }
}
