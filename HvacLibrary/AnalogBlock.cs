using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    /// <summary>
    /// Abstract class for Analog Logic to take care of basic input, output and notification.
    /// </summary>
    public abstract class AnalogBlock : IAnalogInput, IAnalogOutput
    {
        protected double _analogValue = 0;
        private double _outputValue;
        private List<IAnalogOutput> _listeners = new List<IAnalogOutput>();

        public double SignalIn 
        {
            get { return OutputValue; } 
            set 
            { 
                _outputValue = value;
                ResetOutput(value); 
            }
        }
        public double SignalOut 
        { 
            get { return AnalogValue; }
            set { AnalogValue = value; }
        }
        #region "IAnalogInput"
        /// <summary>
        /// Outgoing Value
        /// </summary>
        public double AnalogValue 
        { 
            get
            {
                return _analogValue;
            }
            set
            {
                ResetOutput(value);
            }            
        }

        public void AddListener(IAnalogOutput output)
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
                listener.Update(AnalogValue);
            }
        }

        public void RemoveListener(IAnalogOutput output)
        {
            _listeners.Remove(output);
        }

        #endregion

        #region "IAnalogOutput"
        /// <summary>
        /// Analog signal coming in.
        /// Use Update() to change the value.
        /// </summary>
        public double OutputValue
        {
            get { return _outputValue; }
        }



        public virtual void Update(double newValue)
        {
            _outputValue = newValue;
            ResetOutput(newValue); 
        }
        #endregion

        /// <summary>
        /// This method calculates the new outgoing value.
        /// </summary>
        /// <param name="newValue"></param>
        protected virtual void ResetOutput(double newValue)
        {
            _analogValue = newValue;
        }

    }
}
