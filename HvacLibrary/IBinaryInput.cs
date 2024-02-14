using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    /// <summary>
    /// Represents a component that provides input to other programming components.
    /// </summary>
    public interface IBinaryInput : IInput
    {
        bool Status { get; set; }
        void AddListener(IBinaryOutput output);
        void RemoveListener(IBinaryOutput output);
    }
}
