using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class BinaryOutput : IBinaryOutput
    {
        private bool _command;
        public bool Command
        { get { return _command; } }

        public virtual void Update(bool newStatus)
        {
            _command = newStatus;
        }
        public BinaryOutput() { }
        public BinaryOutput(bool command)
        {
            _command = command;
        }
    }
}
