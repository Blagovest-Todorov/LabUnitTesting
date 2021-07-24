using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeTest() 
    {
        axe = new Axe(10, 10); // attackPointes, durabilityPoints
        dummy = new Dummy(20, 5); //health , experience  // helath -= attackPoints
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        axe.Attack(dummy);

        Assert.That(dummy.Health, Is.EqualTo(10));  // 20-10 / health - attackPoints
        //Assert.AreEqual(10, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked() 
    {
        axe.Attack(dummy);  // then dummy Health = 0;
        axe.Attack(dummy);
        Assert.That(() => axe.Attack(dummy), 
            Throws.InvalidOperationException.With
            .Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP() 
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(5));

    }

    [Test]

    public void AliveDummyCantGiveXP()     
    {
       // axe.Attack(dummy); --there is no need to kill ior to get health form the dummty,
       // //it must be alive , to say Dummy is not dead

        Assert.That(() => dummy.GiveExperience(), 
            Throws.InvalidOperationException.With
            .Message.EqualTo("Target is not dead."));
    }
}
