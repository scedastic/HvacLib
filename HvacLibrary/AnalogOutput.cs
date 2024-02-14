using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    /// <summary>
    /// Accepts an analog signal.
    /// </summary>
    public class AnalogOutput : IAnalogOutput
    {
        private double _outputValue;
        public double OutputValue 
        { 
            get {  return _outputValue; }
        }

        public virtual void Update(double newValue)
        {
            _outputValue = newValue;
        }
    }
}
