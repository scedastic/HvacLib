using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerComponentsLibrary
{
    /// <summary>
    /// Meant to detect whether a piece of equipment is in Alarm. That means, it is off when it's supposed to be on or vice versa. Essentially, there are 
    /// two outputs, one to indicate FAIL (off, when it's supposed to be on) and IN HAND (on, when it's supposed to be off). In keeping with the interface - contract,
    /// instead of throwing a NotImplementedException, if FAIL or IN HAND is on, then "OUTPUT" will be on.
    /// </summary>
    public class ProofBlock : IBinaryToBinaryBlock
    {
        private bool _equipmentStatus;
        private bool _equipmentCommand;
        public bool EquipmentStatus
        {
            get { return _equipmentStatus; }
            set
            {
                _equipmentStatus = value;
                Process();
            }
        }
        public bool EquipmentCommand 
        {
            get { return _equipmentCommand; }
            set
            {
                _equipmentCommand = value;
                Process();
            }
        }

        public bool Fail { get; protected set; }
        public bool InHand { get; protected set; }
        public bool Input { get => EquipmentStatus; set => throw new NotImplementedException(); }
        public bool Output { get => Fail || InHand; set => throw new NotImplementedException(); }

        public void Process()
        {
            Fail = EquipmentCommand && !EquipmentStatus;
            InHand = !EquipmentCommand && EquipmentStatus;
        }
    }
}
