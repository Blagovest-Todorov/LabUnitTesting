using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeTest() 
    {
        axe = new Axe(10, 2);  //attackPoints, durabilityPoints   /// Arrange is here
        dummy = new Dummy(40, 5); //health, expericence
    }

    [Test]
    public void AxeLoosesOneDurabilityPointAfterAttack()    //Act 
    {
        axe.Attack(dummy);   //Calls the method over the object  over the data
        // Assert.That(axe.DurabilityPoints, Is.EqualTo(8));
        Assert.AreEqual(1, axe.DurabilityPoints, "Axe doesnt loose 1 durability point after attack");
    }

    [Test]
    public void AttackWithBrokenAxe()      // Assert -> compare expected with curr result
    {
        axe.Attack(dummy);   //this is the Act - > make an action over the object to see what happends
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy), 
            Throws.InvalidOperationException.With
            .Message.EqualTo("Axe is broken.")); 
    }
}