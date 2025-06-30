using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    /// <summary>
    /// Accepts two analog inputs: OnInput and OffInput. When the Condition is true, the Output will take the OnInput and when it's false it will be OffInput.
    /// When the Condition changes value, the Output is not guaranteed to change until Process() is called.
    /// </summary>
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
