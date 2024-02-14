using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class BinaryInput : IBinaryInput
    {
        private List<IBinaryOutput> _listeners = new List<IBinaryOutput>();

        private bool _status;
        
        /// <summary>
        /// Listeners will be notified ONLY if the new value != the old value.
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set
            {
                
                if (_status != value)
                {
                    _status = value;
                    NotifyListeners();
                }
            }
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
                listener.Update(Status);
            }
        }

        public void RemoveListener(IBinaryOutput output)
        {
            _listeners.Remove(output);
        }

        public BinaryInput() { }
        public BinaryInput(bool status)
        {
            _status = status;
        }
    }
}
