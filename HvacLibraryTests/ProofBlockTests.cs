using HvacLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace HvacLibraryTests
{
    [TestFixture]
    public class ProofBlockTests
    {
        [Test]
        public void DeviceFailureTest()
        {
            var deviceCommand = new BinaryInput();
            var deviceStatus = new BinaryInput();
            var sut = new ProofBlock(deviceCommand, deviceStatus);
            deviceCommand.Status = true;
            deviceStatus.Status = false;
            Assert.That(sut.DeviceFailure, Is.True);
            Assert.That(sut.Alarm, Is.True);
            Assert.That(sut.DeviceInHand, Is.False);
        }
        [Test]
        public void DeviceInHandTest()
        {
            var deviceCommand = new BinaryInput();
            var deviceStatus = new BinaryInput();
            var sut = new ProofBlock(deviceCommand, deviceStatus);
            deviceCommand.Status = false;
            deviceStatus.Status = true;
            Assert.That(sut.DeviceInHand, Is.True);
            Assert.That(sut.DeviceFailure, Is.False);
            Assert.That(sut.Alarm, Is.True);
        }

        [Test]
        public void OffOffNoAlarmTest()
        {
            var deviceCommand = new BinaryInput();
            var deviceStatus = new BinaryInput();
            var sut = new ProofBlock(deviceCommand, deviceStatus);
            deviceCommand.Status = false;
            deviceStatus.Status = false;
            Assert.That(sut.DeviceInHand, Is.False);
            Assert.That(sut.DeviceFailure, Is.False);
            Assert.That(sut.Alarm, Is.False);
        }
        [Test]
        public void OnOnNoAlarmTest()
        {
            var deviceCommand = new BinaryInput();
            var deviceStatus = new BinaryInput();
            var sut = new ProofBlock(deviceCommand, deviceStatus);
            deviceCommand.Status = true;
            deviceStatus.Status = true;
            Assert.That(sut.DeviceInHand, Is.False);
            Assert.That(sut.DeviceFailure, Is.False);
            Assert.That(sut.Alarm, Is.False);
        }
    }
}
