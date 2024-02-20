using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    public class IfGreaterThanBlock : IfBlock
    {
        /// <summary>
        /// Whether to use > vs. >=
        /// </summary>
        public bool Inclusive { get; set; } 

        public IfGreaterThanBlock(double criteria, bool inclusive=false) : base(criteria)
        {
            Inclusive = inclusive;
        }

        public override void Update(double newValue)
        {
            if(!Inclusive && newValue > Criteria)
            {
                _status = true;
            }
            else if(Inclusive && newValue >= Criteria) 
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
