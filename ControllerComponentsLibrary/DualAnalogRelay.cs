using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public class DualAnalogRelay : IAnalogToAnalogBlock
    {
        public double OnInput { protected get; set; }
        public double OffInput { protected get; set; } = 0;
        public double Output { get; protected set; } = 0;
        public double Input
        {
            protected get { return OnInput; }
            set { OnInput = value; }
        }
        public bool Condition { get; set; } = false;
        public void Process()
        {
            if (Condition)
            {
                Output = OnInput;
            }
            else
            {
                Output = OffInput;
            }
        }
    }
}
