using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
   public class FrequencyDomainComponent
    {
        #region Attributes
        public double  Amplitude { get; set; }
        public double  FreqencyInX { get; set; }
        public double FreqencyInY { get; set; }
        public double PhaseShiftInX { get; set; }
        public double PhaseShiftInY { get; set; }
        
        #endregion

        public FrequencyDomainComponent(double p_Amplitude, double p_FreqencyInX, double p_FreqencyInY, double p_PhaseShiftInX, double p_PhaseShiftInY)
        {
            this.Amplitude = p_Amplitude;
            this.FreqencyInX = p_FreqencyInX;
            this.FreqencyInY = p_FreqencyInY;
            this.PhaseShiftInX = p_PhaseShiftInX;
            this.PhaseShiftInY = p_PhaseShiftInY;
        }
    }
}
