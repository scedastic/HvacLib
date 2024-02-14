using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public interface IAnalogInput:IInput
    {
        double AnalogValue { get; set; }
        void AddListener(IAnalogOutput output);
        void RemoveListener(IAnalogOutput output);
    }
}
