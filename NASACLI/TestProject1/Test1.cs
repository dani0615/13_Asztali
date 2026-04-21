using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASACLI;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        [DataRow("Magas;2024;Mars;3;Igen;Leiras;1,5;15000", "Magas")]
        [DataRow("Kozepes1;2024;Mars;3;Igen;Leiras;1,5;5000", "Közepes")]
        [DataRow("Kozepes2;2024;Mars;3;Igen;Leiras;0,5;15000", "Közepes")]
        [DataRow("Alacsony;2024;Mars;3;Igen;Leiras;0,5;5000", "Alacsony")]
        public void KockazatiSzintValidacioTeszt(string sor, string vartEredmeny)
        {
            Kuldetes k = new Kuldetes(sor);
            string tenylegesEredmeny = k.KockazatiSzint();
            Assert.AreEqual(vartEredmeny, tenylegesEredmeny);
        }
    }
}
