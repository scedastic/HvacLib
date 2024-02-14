using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public interface IBinaryOutput
    {
        bool Command { get; }
        void Update(bool newStatus);
    }
}
