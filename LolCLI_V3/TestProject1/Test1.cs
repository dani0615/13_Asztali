using LolCLI_V3;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
       

        [TestMethod]
        [DataRow("Parzival;a mágányos Hős;Fighter;530,8;350;30")]

        public void ArmorLevelTest(string sor)
        {
            Hos ujhos = new Hos(sor);
            Assert.AreEqual(230, ujhos.ArmorLevel(10));
            Assert.AreEqual(50, ujhos.ArmorLevel(1));
            Assert.AreEqual(130, ujhos.ArmorLevel(5));
            Assert.AreEqual(390, ujhos.ArmorLevel(18));


        }
    }
}
