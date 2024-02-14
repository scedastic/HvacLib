using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class BinaryBlock : IBinaryInput, IBinaryOutput
    {
        private bool _status;
        private bool _command;
        private List<IBinaryOutput> _listeners; 

        #region "IBinaryInput"
        
        /// <summary>
        /// Outgoing Signal
        /// </summary>
        public bool Status 
        {
            get { return _status; }
            set => throw new NotImplementedException("Changing the status should be done via Update()"); 
        }

        public void AddListener(IBinaryOutput output)
        {
            _listeners.Add(output);
        }

        public void ClearListeners()
        {
            _listeners.Clear();
        }

        public void NotifyListeners()
        {
            foreach(var listener in _listeners)
            {
                listener.Update(_status);
            }
        }

        public void RemoveListener(IBinaryOutput output)
        {
            _listeners.Remove(output);
        }
        #endregion

        #region "IBinaryOutput"
        /// <summary>
        /// Incoming Signal
        /// </summary>
        public bool Command { get { return _command; } }


        public void Update(bool newStatus)
        {
            _status = newStatus;
            NotifyListeners();
        }
        #endregion

        public BinaryBlock()
        {
            _listeners = new List<IBinaryOutput>();
        }
    }
}
