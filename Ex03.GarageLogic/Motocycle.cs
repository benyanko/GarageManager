using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Motocycle : Vehicle
    {
        private readonly int r_NumOfWheels = 2;
        private readonly float m_MaximumWheelsAirPressure = 30;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motocycle(float i_CurrentAirPressure)
        {
            this.m_LicenseType = eLicenseType.Undefind;
            this.m_EngineVolume = 0;
            Wheels = new List<Wheel>(r_NumOfWheels);
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(m_MaximumWheelsAirPressure, i_CurrentAirPressure);
                Wheels.Add(wheel);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
 @"{0}
License type: {1}
Engine volume: {2}
",
            base.ToString(), this.m_LicenseType, this.m_EngineVolume);
        }
    }
}