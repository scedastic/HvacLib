using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public class AnalogRelay : IAnalogToAnalogBlock
    {
        public double Input { protected get; set; }
        public double Output { get; protected set; } = 0;

        public bool Condition { get; set; } = false;
        public void Process()
        {
            if (Condition)
            {
                Output = Input;
            }
            else
            {
                Output = 0;
            }
        }
    }
}
