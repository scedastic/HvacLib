using HvacLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibraryTests
{
    [TestFixture]
    public class RatioBlockTests
    {
        /// <summary>
        /// Set up a ratio block where inputs from 1 - 100 are scaled 1 - 100
        /// </summary>
        /// <param name="inputOutputValue"></param>
        [Test]
        [TestCase(100)]
        [TestCase(30)]
        [TestCase(0)]
        public void DirectRatioBlock(double inputOutputValue)
        {
            var block = SetupBlock(0, 100, 0, 100);
            block.SignalIn = inputOutputValue;
            Assert.That(block.SignalOut, Is.EqualTo(block.SignalIn), $"Signal Out is {block.SignalOut} but is supposed to be {block.SignalIn}");
        }

        [Test]
        public void InputAboveHighLimitTest()
        {
            var block = SetupBlock(10, 50, 10, 75);
            block.SignalIn = 100;
            Assert.That(block.SignalOut, Is.EqualTo(block.OutHighLimit));
        }
        [Test]
        public void InputBelowLowLimitTest()
        {
            RatioBlock block = SetupBlock(10, 50, 10, 75);
            block.SignalIn = -100;
            Assert.That(block.SignalOut, Is.EqualTo(block.OutLowLimit));
        }

        private static RatioBlock SetupBlock(double inLow, double inHigh, double outLow, double outHigh)
        {
            var block = new RatioBlock();
            block.InLowLimit = inLow;
            block.InHighLimit = inHigh;
            block.OutLowLimit = outLow;
            block.OutHighLimit = outHigh;
            return block;
        }

        [Test]
        public void InverseRatioTest()
        {
            var block = SetupBlock(0, 100, 100, 0);
            block.SignalIn = 25;
            Assert.That(block.SignalOut, Is.EqualTo(75));
        }
    }
}
