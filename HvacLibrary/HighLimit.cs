using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class HighLimit : AnalogBlock
    {
        public double Limit { get; set; }

        protected override void ResetOutput(double newValue)
        {
            _analogValue = newValue < Limit ? newValue : Limit;
        }
    }
}
