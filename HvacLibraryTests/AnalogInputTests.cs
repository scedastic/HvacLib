using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HvacLibrary;
using Moq;
using NUnit;

namespace HvacLibraryTests
{
    [TestFixture]
    public class AnalogInputTests
    {
        [Test]
        public void ListenersAreNotifiedPositiveChange()
        {
            var input = new AnalogInput();
            var mockOutput = new Mock<IAnalogOutput>();
            input.AddListener(mockOutput.Object);
            input.AnalogValue += 10;
            mockOutput.Verify(x => x.Update(It.IsAny<double>()));
        }

        [Test]
        public void ListenersAreNotifiedNegativeChange()
        {
            double threshhold = 5;
            var input = new AnalogInput(0, threshhold);
            var mockOutput = new Mock<IAnalogOutput>();
            input.AddListener(mockOutput.Object);
            input.AnalogValue -= threshhold;
            mockOutput.Verify(x => x.Update(It.IsAny<double>()));
        }

        [Test]
        public void ListenersAreNotNotifiedWhenChangeIsLessThanThreshhold()
        {
            double threshhold = 10;
            var input = new AnalogInput(3, threshhold);
            var mockOutput = new Mock<IAnalogOutput>();
            input.AddListener(mockOutput.Object);
            input.AnalogValue += threshhold - 0.1;
            mockOutput.VerifyNoOtherCalls();
        }
        [Test]
        public void ListenersAreNotifiedWhenChangeIsGreaterThanThreshhold()
        {
            double threshhold = 10;
            var input = new AnalogInput(3, threshhold);
            var mockOutput = new Mock<IAnalogOutput>();
            input.AddListener(mockOutput.Object);
            input.AnalogValue += threshhold - 0.1;
            mockOutput.VerifyNoOtherCalls();
            input.AnalogValue += 0.1;
            mockOutput.Verify(x => x.Update(It.IsAny<double>()));
        }
        [Test]
        public void ListenersAreNotNotifiedWhenChangeIsLessThanThreshholdChangeIsUpAndDown()
        {
            double threshhold = 10;
            var input = new AnalogInput(3, threshhold);     // input == 3
            var mockOutput = new Mock<IAnalogOutput>();
            input.AddListener(mockOutput.Object);
            input.AnalogValue += threshhold - 0.1;          // input == 12.9 == 3 + 10 - 0.1
            mockOutput.VerifyNoOtherCalls();

            input.AnalogValue -= threshhold;                // input == 2.9 == 12.9 - 10
            mockOutput.VerifyNoOtherCalls();
        }
    }
    
}
