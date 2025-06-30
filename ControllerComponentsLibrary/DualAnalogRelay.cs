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
        private double _onInput;
        private double _offInput;
        private bool _condition;

        public double OnInput 
        { 
            protected get
            {
                return _onInput;
            } 
            set
            {
                _onInput = value;
                Process();
            }
        }
        public double OffInput
        {
            protected get
            {
                return _offInput;
            }
            set
            {
                _offInput = value;
                Process();
            }
        }
        public double Output { get; protected set; } = 0;
        public double Input
        {
            protected get { return OnInput; }
            set { OnInput = value; }
        }
        public bool Condition 
        {
            get { return _condition; }
            set
            {
                _condition = value;
                Process();
            }
        
        } 
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
