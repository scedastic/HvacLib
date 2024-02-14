using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvacLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class RatioBlock : AnalogBlock
    {
        /// <summary>
        /// All incoming values greater than InHighLimit will be set to InHighLimit.
        /// </summary>
        public double InHighLimit { get; set; }
        /// <summary>
        /// All incoming values less than InLowLimit will be set to InLowLimit.
        /// </summary>
        public double InLowLimit { get; set; }

        /// <summary>
        /// This is the outgoing signal when the incoming signal is greater than or equal to InHighLimit.
        /// </summary>
        public double OutHighLimit { get; set; }

        /// <summary>
        /// This is the outgoing signal when the incoming signal is less than or equal to InLowLimit.
        /// </summary>
        public double OutLowLimit { get; set;}

        protected override void ResetOutput(double newValue)
        {
            if (SignalIn > InHighLimit)
                _analogValue = OutHighLimit;
            else if(SignalIn < InLowLimit) 
                _analogValue = InLowLimit;
            else
            {
                // Signal In is in range.
                var ratio = (InHighLimit - InLowLimit) / (OutHighLimit - OutLowLimit);
                _analogValue = (newValue - InLowLimit) * ratio + OutLowLimit ;
            }
            
        }
    }
}
