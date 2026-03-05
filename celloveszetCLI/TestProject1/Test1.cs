using celloveszetCLI;
namespace TestProject1
{
    [TestClass]
    public sealed class LoveszTest
    {
        [TestMethod]
        public void LegnagyobbTest()
        {

            var lovesz = new Lovesz("Teszt1;22;29;12;23");
            Assert.AreEqual(29, lovesz.Legnagyobb());

            var lovesz2 = new Lovesz("Teszt2;16;45;87;33");
            Assert.AreEqual(87, lovesz2.Legnagyobb());

            var lovesz3 = new Lovesz("Teszt3;96;49;67;45");
            Assert.AreEqual(96, lovesz3.Legnagyobb());

            var lovesz4 = new Lovesz("Teszt4;44;3;12;77");
            Assert.AreEqual(77, lovesz4.Legnagyobb());

        }
    }
}
