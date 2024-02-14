using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class AnalogInput : IAnalogInput
    {
        private double _analogValue = 0.0;
        private double _threshhold = 0.0;
        private double lastThreshholdValue = 0.0;
        private List<IAnalogOutput> _listeners = new List<IAnalogOutput>();

        /// <summary>
        /// On change, if the difference is greater than the thresshold, then we will notify listeners.
        /// Otherwise we just change the AnalogValue, but we will keep the old value, so that on
        /// the next change, if the accumulation is above the threshhold we will notify the listeners.
        /// </summary>
        public double AnalogValue
        {
            get { return _analogValue; }
            set
            {
                _analogValue = value;
                if (Math.Abs(lastThreshholdValue - _analogValue) >= _threshhold)
                {                    
                    lastThreshholdValue = value;
                    NotifyListeners();
                }
            }
        }


        public AnalogInput() { }
        /// <summary>
        /// Initialize the Value and the Threshhold
        /// </summary>
        /// <param name="analogValue"></param>
        /// <param name="threshhold">How much of a change is necessary to trigger a Notify event.</param>
        public AnalogInput(double analogValue, double threshhold) 
        {
            AnalogValue = analogValue;
            _threshhold = threshhold;
        }

        public void AddListener(IAnalogOutput output)
        {
            _listeners.Add(output);
        }

        public void ClearListeners()
        {
            _listeners.Clear();
        }

        /// <summary>
        /// Belongs to the object being watched.
        /// </summary>
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
    }
}
