using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class IfLessThanBlock : IfBlock
    {
        public IfLessThanBlock(double criteria, bool inclusive) : base(criteria)
        {
            Inclusive = inclusive;
        }

        public override void Update(double newValue)
        {
            if (!Inclusive && newValue < Criteria)
            {
                _status = true;
            }
            else if (Inclusive && newValue <= Criteria)
            {
                _status = true;
            }
            else
            {
                _status = false;
            }

        }
    }
}
