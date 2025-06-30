using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public class Inverter : IBinaryToBinaryBlock
    {
        private bool _input;
        public bool Input { get { return _input; } 
            set {
                _input = value;
                Process();
            }
        }
        public bool Output { get; set; }

        public void Process()
        {
            Output = !Input;
        }
    }
}
