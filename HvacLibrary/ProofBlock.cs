namespace HvacLibrary
{
    /// <summary>
    /// – Has two binary inputs and two binary outputs. Monitors two binary values (usually one input and one output such as  damper command and damper status) 
    /// so that if they don’t match it raises one of two alarms, depending on which is on vs. which is off.
    /// </summary>
    public class ProofBlock : IBinaryOutput, IBinaryInput
    {
        private List<IBinaryOutput> _listeners = new List<IBinaryOutput>();
        private List<IBinaryOutput> _inHandListeners = new List<IBinaryOutput>();
        private List<IBinaryOutput> _failListeners = new List<IBinaryOutput>();
        public IBinaryInput DeviceCommand { get; set; }
        public IBinaryInput DeviceStatus { get; set; }

        public bool Alarm { get { return DeviceFailure || DeviceInHand; } }
        public bool DeviceFailure { get { return DeviceCommand.Status && !DeviceStatus.Status; } }
        public bool DeviceInHand { get { return !DeviceCommand.Status && DeviceStatus.Status; } }

        public bool Command => throw new NotImplementedException();

        /// <summary>
        /// Whether Device is Failed or InHand
        /// </summary>
        public bool Status { get => Alarm; set => throw new NotImplementedException(); }

        public ProofBlock(IBinaryInput deviceCommand, IBinaryInput deviceStatus)
        {
            DeviceCommand = deviceCommand;
            DeviceCommand.AddListener(this);
            DeviceStatus = deviceStatus;
            DeviceStatus.AddListener(this);
        }

        public void Update(bool newStatus)
        {
            NotifyListeners();
            NotifyFailListeners();
            NotifyInHandListeners();
        }

        public void AddListener(IBinaryOutput output)
        {
            addListener(output, _listeners);
        }

        public void RemoveListener(IBinaryOutput output)
        {
            removeListener(output, _listeners);
        }

        public void NotifyListeners()
        {
            notifyListeners(_listeners);
        }

        public void ClearListeners()
        {
            _listeners.Clear();
        }

        public void AddFailListener(IBinaryOutput output)
        {
            addListener(output, _failListeners);
        }
        public void RemoveFailListener(IBinaryOutput output)
        {
            removeListener(output, _failListeners);
        }

        public void NotifyFailListeners()
        {
            notifyListeners(_failListeners);
        }

        public void ClearFailListeners()
        { _failListeners.Clear(); }

        public void AddInHandListener(IBinaryOutput output)
        {
            addListener(output, _inHandListeners);
        }
        public void RemoveInHandListener(IBinaryOutput output)
        {
            removeListener(output, _inHandListeners);
        }

        public void NotifyInHandListeners()
        {
            notifyListeners(_inHandListeners);
        }

        public void ClearInHandListener()
        { _inHandListeners.Clear(); }

        private void addListener(IBinaryOutput output, List<IBinaryOutput> listing)
        {
            listing.Add(output);
        }
        private void removeListener(IBinaryOutput output, List<IBinaryOutput> listing)
        {
            listing.Remove(output);
        }

        private void notifyListeners(List<IBinaryOutput> listing)
        {
            foreach (var listener in _listeners)
            {
                listener.Update(Status);
            }
        }
    }
}
