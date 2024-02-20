using HvacLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibraryTests
{
    [TestFixture]
    public class IfLessThanBlockTests
    {
        [Test]
        [TestCase(10, 20, false)]
        [TestCase(-10, 20, false)]
        [TestCase(-10, -0, false)]
        [TestCase(10, 5, true)]
        [TestCase(10, -5, true)]
        [TestCase(-1, -5, true)]
        public void IfLessThanTests(int criteria, int input, bool closed)
        {
            var sut = new IfLessThanBlock(criteria, false);
            sut.Update(input);
            Assert.That(sut.Status, Is.EqualTo(closed));

        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10000)]
        public void IfEqualToTests(int criteria)
        {
            var sut = new IfLessThanBlock(criteria, true);
            sut.Update(criteria);
            Assert.That(sut.Status, Is.EqualTo(true));

        }
    }
}
