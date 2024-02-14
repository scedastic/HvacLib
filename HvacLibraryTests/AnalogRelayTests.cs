using HvacLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibraryTests
{
    public class AnalogRelayTests
    {
        [Test]
        public void OpenRelayTakesDefaultValue()
        {
            double minVfdSpeed = 20.0;
            double operatingSpeed = 80.0;
            var vfd = new AnalogOutput();
            var operatingPower = new AnalogInput();
            var motorSwitch = new BinaryInput();
            var sut = new AnalogRelay(minVfdSpeed);
            motorSwitch.AddListener(sut);
            sut.AddListener(vfd);
            operatingPower.AddListener(sut);
            motorSwitch.Status = false;
            operatingPower.AnalogValue = operatingSpeed;
            Assert.That(vfd.OutputValue, Is.EqualTo(minVfdSpeed));

        }

        [Test]
        public void ClosedRelayTakesOutputValue()
        {

            double minVfdSpeed = 20.0;
            double operatingSpeed = 80.0;
            var vfd = new AnalogOutput();
            var operatingPower = new AnalogInput();
            var motorSwitch = new BinaryInput();
            var sut = new AnalogRelay(minVfdSpeed);
            motorSwitch.AddListener(sut);
            sut.AddListener(vfd);
            operatingPower.AddListener(sut);
            motorSwitch.Status = true;
            operatingPower.AnalogValue = operatingSpeed;
            Assert.That(vfd.OutputValue, Is.EqualTo(operatingSpeed));
        }

        [Test]
        public void ChangingCommandChangesTheAnalogValue()
        {
            double minVfdSpeed = 20.0;
            double operatingSpeed = 80.0;
            var vfd = new AnalogOutput();
            var operatingPower = new AnalogInput();
            var motorSwitch = new BinaryInput();
            var sut = new AnalogRelay(minVfdSpeed);
            motorSwitch.AddListener(sut);
            sut.AddListener(vfd);
            operatingPower.AddListener(sut);
            motorSwitch.Status = true;
            operatingPower.AnalogValue = operatingSpeed;
            Assert.That(vfd.OutputValue, Is.EqualTo(operatingSpeed));
            motorSwitch.Status = false;
            Assert.That(vfd.OutputValue, Is.EqualTo(minVfdSpeed));
        }
    }
}
