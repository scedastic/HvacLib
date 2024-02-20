﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class IfBlock : IAnalogOutput, IBinaryInput
    {
        protected bool _status;
        private List<IBinaryOutput> _listeners = new List<IBinaryOutput>();
        public double Criteria { get; set; }

        public IfBlock(double criteria)
        { this.Criteria = criteria; }


        public double OutputValue { get; }
        public bool Status 
        { 
            get { return _status; } 
            set => throw new NotImplementedException(); 
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

        public virtual void Update(double newValue)
        {
            throw new NotImplementedException();
        }
    }
}
