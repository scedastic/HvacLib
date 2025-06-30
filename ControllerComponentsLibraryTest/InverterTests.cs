using ControllerComponentsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibraryTest
{
    [TestFixture]
    public class InverterTests
    {
        [Test]
        public void InputTrueOutputFalse_TestPass()
        {
            var testComponent = new Inverter();
            testComponent.Input = true;
            Assert.That(testComponent.Output, Is.False);
        }
        [Test]
        public void InputFalseOutputTrue_TestPass()
        {
            var testComponent = new Inverter();
            testComponent.Input = false;
            Assert.That(testComponent.Output, Is.True);
        }
    }
}
