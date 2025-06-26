using ControllerComponentsLibrary;

namespace ControllerComponentsLibraryTest;

public class AnalogRelayTests
{
    protected AnalogRelay subject;
    [SetUp]
    public void Setup()
    {
        subject = new AnalogRelay();
    }

    [Test]
    public void PositiveValueOnTest()
    {
        subject.Input = 13.0;
        subject.Condition = true;
        subject.Process();
        Assert.That(Is.Equals(13.0, subject.Output));
    }
    [Test]
    public void PositiveValueOffTest()
    {
        subject.Input = 13.0;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(0.0, subject.Output));
    }
    [Test]
    public void NegativeValueOnTest()
    {
        subject.Input = -1113.0;
        subject.Condition = true;
        subject.Process();
        Assert.That(Is.Equals(-1113.00, subject.Output));
    }
    [Test]
    public void NegativeValueOffTest()
    {
        subject.Input = -1113.0;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(0.0, subject.Output));
    }
    [Test]
    public void ZeroValueOnTest()
    {
        subject.Input = 0.0;
        subject.Condition = true;
        subject.Process();
        Assert.That(Is.Equals(0.0, subject.Output));
    }
    [Test]
    public void ZeroValueOffTest()
    {
        subject.Input = 0.0;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(0.0, subject.Output));
    }

    [Test]
    public void ChangeOfConditionTest()
    {
        subject.Input = 13.0;
        subject.Condition = false;
        subject.Process();
        Assert.That(Is.Equals(0.0, subject.Output));
        subject.Condition = true;
        Assert.That(Is.Equals(0.0, subject.Output));
        subject.Process();
        Assert.That(Is.Equals(13.0, subject.Output));
    }
}
