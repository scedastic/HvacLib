using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    /// <summary>
    /// Object being observed.
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// Belongs to object being observed.
        /// </summary>
        void NotifyListeners();
        void ClearListeners();
    }

}
