using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public class Inverter : IBinaryToBinaryBlock
    {
        public bool Input { get; set; }
        public bool Output { get; set; }

        public void Process()
        {
            Output = !Input;
        }
    }
}
