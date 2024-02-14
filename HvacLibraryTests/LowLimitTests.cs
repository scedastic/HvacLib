using HvacLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibraryTests
{
    [TestFixture]
    public class LowLimitTests
    {
        [Test]
        public void InputInRangeTest()
        {
            LowLimit sut = new LowLimit();
            sut.Limit = 10;
            sut.Update(16);
            Assert.That(sut.SignalOut, Is.EqualTo(16));
        }
        [Test]
        [TestCase(10, 2)]
        [TestCase(4, -1)]
        [TestCase(-10, -23)]
        public void InputBelowLimitUsesLimitTest(double limit, double newValue)
        {

            LowLimit sut = new LowLimit();
            sut.Limit = limit;
            sut.Update(newValue);
            Assert.That(sut.SignalOut, Is.EqualTo(limit));
        }
    }
}
