using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public interface IAnalogToAnalogBlock : IBlock
    {
        double Input { set; }
        double Output { get; }
    }
}
