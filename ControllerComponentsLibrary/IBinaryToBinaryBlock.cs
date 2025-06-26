using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    public interface IBinaryToBinaryBlock : IBlock
    {
        public bool Input {  internal get; set; }
        public bool Output { get; internal set; }
    }
}
