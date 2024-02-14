using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class AnalogRelay : IAnalogInput, IBinaryOutput, IAnalogOutput
    {
        private List<IAnalogOutput> _listeners = new List<IAnalogOutput>();


        public double DefaultValue;
        public double OutputValue { get; set; }

        /// <summary>
        /// When true, the AnalogValue will be whatever the Analog Input is
        /// </summary>
        public bool Command { get; set; }
        public double AnalogValue 
        { 
            get
            { 
                if (Command) return OutputValue;
                else return DefaultValue;
            }
    
            set => throw new NotImplementedException(); 
        }

        public void Update(double newValue)
        {
            OutputValue = newValue;
            NotifyListeners();
        }

        public void Update(bool newStatus)
        {
            Command = newStatus;
            NotifyListeners();
        }

        public void AddListener(IAnalogOutput output)
        {
            _listeners.Add(output);
        }

        public void RemoveListener(IAnalogOutput output)
        {
            _listeners.Remove(output);
        }

        public void NotifyListeners()
        {
            foreach(var listener in _listeners)
            {
                listener.Update(AnalogValue);
            }
        }

        public void ClearListeners()
        {
            _listeners.Clear();
        }

        public AnalogRelay(double defaultValue)
        {
            DefaultValue = defaultValue;
            OutputValue = defaultValue;
        }
    }
}
