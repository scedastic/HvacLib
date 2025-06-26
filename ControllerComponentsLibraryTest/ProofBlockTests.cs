using ControllerComponentsLibrary;

namespace ControllerComponentsLibraryTest;

[TestFixture]
public class ProofBlockTests
{
    private ProofBlock alarm;

    [SetUp]
    public void SetUp()
    {
        alarm = new ProofBlock();
    }

    [Test]
    public void CommandOnStatusOffIsFailTest()
    {
        alarm.EquipmentCommand = true;
        alarm.EquipmentStatus = false;
        alarm.Process();
        Assert.That(alarm.Fail, Is.True);
        Assert.That(alarm.InHand, Is.False);
    }
    [Test]
    public void CommandOffStatusOnIsInHandTest()
    {
        
        alarm.EquipmentCommand = false;
        alarm.EquipmentStatus = true;
        alarm.Process();
        Assert.That(alarm.Fail, Is.False);
        Assert.That(alarm.InHand, Is.True);
    }

    [Test]
    public void CommandOnStatusOnNoAlarmsTest()
    {
        alarm.EquipmentCommand = true;
        alarm.EquipmentStatus = true;
        alarm.Process();
        Assert.That(alarm.Fail, Is.False);
        Assert.That(alarm.InHand, Is.False);
    }
    [Test]
    public void CommandOffStatusOffNoAlarmsTest()
    {
        alarm.EquipmentCommand = false;
        alarm.EquipmentStatus = false;
        alarm.Process();
        Assert.That(alarm.Fail, Is.False);
        Assert.That(alarm.InHand, Is.False);
    }
    [Test]
    public void BothAlarmsSetOutputTrueTest()
    {
        alarm.EquipmentCommand = false;
        alarm.EquipmentStatus = true;
        alarm.Process();
        Assert.That(alarm.Output, Is.True);
        alarm.EquipmentCommand = true;
        alarm.EquipmentStatus = false;
        alarm.Process();
        Assert.That(alarm.Output, Is.True);
    }
    [Test]
    public void NoAlarmsSetOutputFalseTest()
    {
        alarm.EquipmentCommand = false;
        alarm.EquipmentStatus = false;
        alarm.Process();
        Assert.That(alarm.Output, Is.False);
        alarm.EquipmentCommand = true;
        alarm.EquipmentStatus = true;
        alarm.Process();
        Assert.That(alarm.Output, Is.False);
    }
}
