using HvacLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibraryTests
{
    [TestFixture]
    public class HighLimitTests
    {
        [Test]
        public void InputInRangeTest()
        {
            HighLimit sut = new HighLimit();
            sut.Limit = 10;
            sut.Update(6);
            Assert.That(sut.SignalOut, Is.EqualTo(6));
        }
        [Test]
        [TestCase(10, 20)]
        [TestCase(-4, 12)]
        [TestCase(-10, -3)]
        public void InputAboveLimitUsesLimitTest(double limit, double newValue)
        {

            HighLimit sut = new HighLimit();
            sut.Limit = limit;
            sut.Update(newValue);
            Assert.That(sut.SignalOut, Is.EqualTo(limit));
        }
    }
}
