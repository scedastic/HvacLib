using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HvacLibrary;
using Moq;

namespace HvacLibraryTests
{
    [TestFixture]
    public class BinaryInputTests
    {
        /// <summary>
        /// Create mock Outputs that will make sure that Update was called.
        /// </summary>
        [Test]
        public void ListenersAreNotified()
        {
            var input = new BinaryInput();
            var mockOutput = new Mock<IBinaryOutput>();
            input.AddListener(mockOutput.Object);
            input.Status = !input.Status;
            mockOutput.Verify(x => x.Update(It.IsAny<bool>())); 
        }
    }
}
