using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        private string r_ErrorMessage;

        public Wheel(float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            if (i_CurrentAirPressure > i_MaxAirPressure || i_CurrentAirPressure <= 0)
            {
                r_ErrorMessage = (string.Format("Invalid air pressure amount. Please insert the amount in the range 0 - {0}", i_MaxAirPressure));
                throw new ValueOutOfRangeException(0.0f, i_MaxAirPressure, r_ErrorMessage);
            }
            else
            {
                this.m_ManufacturerName = string.Empty;
                this.m_CurrentAirPressure = i_CurrentAirPressure;
                this.m_MaxAirPressure = i_MaxAirPressure;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return this.m_ManufacturerName;
            }

            set
            {
                this.m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }

            set
            {
                this.m_MaxAirPressure = value;
            }
        }

        public void inflateAction(float i_AirToAdd)
        {
            if (i_AirToAdd < 0 || this.m_CurrentAirPressure + i_AirToAdd > this.m_MaxAirPressure)
            {
                throw new Exception("The amount of air requested is invalid");
            }
            else
            {
                this.m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public void inflateActionToMaximum()
        {
            this.m_CurrentAirPressure = m_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
@"Manufacturer Name: {0} 
Current air pressure: {1}
Maximum air pressure: {2}",
            this.m_ManufacturerName, this.m_CurrentAirPressure, this.m_MaxAirPressure);
        }
    }
}