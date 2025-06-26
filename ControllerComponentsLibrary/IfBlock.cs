using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public class IfBlock : IAnalogToBinaryBlock
    {
        public double Input { protected get; set; }
        public bool Output { get; protected set; }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}
