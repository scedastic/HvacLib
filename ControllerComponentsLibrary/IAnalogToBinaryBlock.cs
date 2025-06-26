using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public interface IAnalogToBinaryBlock : IBlock
    {
        public double Input {  set; }
        public bool Output { get; }
    }
}
