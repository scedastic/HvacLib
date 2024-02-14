using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    /// <summary>
    /// Observer.
    /// </summary>
    public interface IAnalogOutput
    {
        double OutputValue { get; }
        /// <summary>
        /// Belongs to the Observer object.
        /// </summary>
        /// <param name="newValue"></param>
        void Update(double newValue);
    }
}
