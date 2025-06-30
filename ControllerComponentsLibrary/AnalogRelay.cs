using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public class AnalogRelay : IAnalogToAnalogBlock
    {
        private double _input;
        private bool _condition;

        public double Input 
        {
            protected get { return _input; }
            set
            {
                _input = value;
                Process();
            } 
        }
        public double Output { get; protected set; } 

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
                Output = _input;
            }
            else
            {
                Output = 0;
            }
        }
    }
}
