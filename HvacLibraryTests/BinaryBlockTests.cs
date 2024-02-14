using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HvacLibrary;
using NUnit;

namespace HvacLibraryTests
{
    [TestFixture]     
    public class BinaryBlockTests
    {
        [Test]
        public void InputShouldChangeOutput()
        {
            var block = new BinaryBlock();
            var input = new BinaryInput(false);
            var output = new BinaryOutput(false);
            input.AddListener(block);
            block.AddListener(output);
            input.Status = !input.Status;
            Assert.That(output.Command, Is.EqualTo(input.Status));

        }

        [Test]
        public void InputShouldChangeOutput_MultipleBinaryBlocks()
        {
            int chainOfBlocks = 1000;
            var input = new BinaryInput(false);
            var output = new BinaryOutput(false);
            List<BinaryBlock> blocks = new List<BinaryBlock>();

            for (var i = 0; i < chainOfBlocks; i++)
            {
                var bBlock = new BinaryBlock();
                blocks.Add(bBlock);
                if(i == 0)
                {
                    input.AddListener(bBlock);
                }
                else
                {
                    blocks[i-1].AddListener(bBlock);
                }
            }
            blocks[chainOfBlocks - 1].AddListener(output);
            input.Status = !input.Status;
            Assert.That(output.Command, Is.EqualTo(input.Status));
        }
    }
}
