using ControllerComponentsLibrary;

namespace ControllerComponentsLibraryTest;

public class DualAnalogRelayTests
{
    protected DualAnalogRelay subject;
    private double onValue = 13.0;
    private double offValue = 2.1;
    private double negativeOnValue = -142.6;
    private double negativeOffValue = -1042.9;

    [SetUp]
    public void Setup()
    {
        subject = new DualAnalogRelay();
    }

    [Test]
    public void PositiveValueOnTest()
    {

        subject.OnInput = onValue;
        subject.OffInput = offValue;
        subject.Condition = true;
        Assert.That(Is.Equals(onValue, subject.Output));
    }
    [Test]
    public void PositiveValueOffTest()
    {
        subject.OnInput = onValue;
        subject.OffInput = offValue;
        subject.Condition = false;
        Assert.That(Is.Equals(offValue, subject.Output));
    }
    [Test]
    public void NegativeValueOnTest()
    {
        subject.OnInput = negativeOnValue;
        subject.OffInput = offValue;
        subject.Condition = true;
        Assert.That(Is.Equals(negativeOnValue, subject.Output));
    }
    [Test]
    public void NegativeValueOffTest()
    {
        subject.OnInput = negativeOnValue;
        subject.OffInput = negativeOffValue;
        subject.Condition = false;
        Assert.That(Is.Equals(negativeOffValue, subject.Output));
    }
    [Test]
    public void ZeroValueOnTest()
    {
        subject.OnInput = 0.0;
        subject.OffInput = offValue;
        subject.Condition = true;
        Assert.That(Is.Equals(0.0, subject.Output));
    }
    [Test]
    public void ZeroValueOffTest()
    {
        subject.OnInput = 0.0;
        subject.OffInput = offValue;
        subject.Condition = false;
        Assert.That(Is.Equals(offValue, subject.Output));
    }

    [Test]
    public void ChangeOfConditionTest()
    {
        subject.OnInput = onValue;
        subject.OffInput = offValue;
        subject.Condition = false;
        Assert.That(Is.Equals(offValue, subject.Output));
        subject.Condition = true;
        Assert.That(Is.Equals(onValue, subject.Output));
    }
}
