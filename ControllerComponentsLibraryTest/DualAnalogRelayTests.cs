using ControllerComponentsLibrary;

namespace ControllerComponentsLibraryTest;

public class DualAnalogRelayTests
{
    protected DualAnalogRelay subject;
    private double onValue = 13.0;
    private double offValue = 2.1;

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
        subject.Process();
        Assert.That(Is.Equals(onValue, subject.Output));
    }
    [Test]
    public void PositiveValueOffTest()
    {
        subject.OnInput = onValue;
        subject.OffInput = offValue;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(offValue, subject.Output));
    }
    [Test]
    public void NegativeValueOnTest()
    {
        subject.OnInput = -1113.0;
        subject.OffInput = offValue;
        subject.Condition = true;
        subject.Process();
        Assert.That(Is.Equals(-1113.00, subject.Output));
    }
    [Test]
    public void NegativeValueOffTest()
    {
        subject.OnInput = -1113.0;
        subject.OffInput = offValue;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(offValue, subject.Output));
    }
    [Test]
    public void ZeroValueOnTest()
    {
        subject.OnInput = 0.0;
        subject.OffInput = offValue;
        subject.Condition = true;
        subject.Process();
        Assert.That(Is.Equals(0.0, subject.Output));
    }
    [Test]
    public void ZeroValueOffTest()
    {
        subject.OnInput = 0.0;
        subject.OffInput = offValue;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(offValue, subject.Output));
    }

    [Test]
    public void ChangeOfConditionTest()
    {
        subject.OnInput = onValue;
        subject.OffInput = offValue;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(offValue, subject.Output));
        subject.Condition = true;
        Assert.That(Is.Equals(offValue, subject.Output));
        subject.Process();
        Assert.That(Is.Equals(onValue, subject.Output));
    }
}
