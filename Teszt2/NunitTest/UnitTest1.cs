namespace NunitTest;
using Teszt2;

public class Tests
{

    Alap alap = null;
    [SetUp]
    public void Setup()
    {
        alap = new Alap();
    }

    [TearDown]
    public void TearDown()
    {
        alap = null;
    }
    [Test]
    [TestCase("alma", 2, "alMa")]
    [TestCase("banan", 1, "bAnan")]
    [TestCase("alma", -1, "alma")]
    public void NagyBetuTest(string szoveg, int index, string elvart)
    {
        Assert.That(elvart, Is.EqualTo(alap.NagyBetu(szoveg, index)));
    }


    [Test]
    [TestCase("alma", 7)]
    public void NagyBetuArgumentOutOfRange(string szoveg, int index)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => alap.NagyBetu(szoveg, index));

    }

    [Test]

    public void Rnd([Random(-10 , 10 , 50)] int r) 
    {
        Console.WriteLine(r);
    }

    [Test]
    public void Range([Range(1,15,2)] int r) 
    {
        Console.WriteLine(r);
    }

    [Test, Combinatorial]
    public void Kombinatorika(
        [Values("a","b")] string elso , 
        [Values("+" , "-")] string masodik, 
        [Values("X", "Y","Z")] string harmadik)
    { Console.WriteLine(elso); }

    [Test, Pairwise]
    public void Agak(
       [Values("a", "b")] string elso,
       [Values("+", "-")] string masodik,
       [Values("X", "Y", "Z")] string harmadik)
    { Console.WriteLine(elso); }

    [Test, Sequential]
    public void Sorrend(
      [Values("a", "b")] string elso,
      [Values("+", "-")] string masodik,
      [Values("X", "Y", "Z")] string harmadik)
    { Console.WriteLine(elso); }
}
