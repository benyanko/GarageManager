using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Car : Vehicle
    {
        private readonly int r_NumberOfWheels = 4;
        private readonly int r_MaxAirPressure = 32;
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;

        public Car(float i_CurrentAirPressure)
        {
            this.m_Color = eColor.Undefined;
            this.m_NumOfDoors = 0;
            Wheels = new List<Wheel>(r_NumberOfWheels);
            for (int i = 0; i < r_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel(r_MaxAirPressure, i_CurrentAirPressure);
                Wheels.Add(wheel);
            }
        }

        public eColor Color
        {
            get
            {
                return this.m_Color;
            }

            set
            {
                this.m_Color = value;
            }
        }

        public eNumOfDoors NumberOfDoors
        {
            get
            {
                return this.m_NumOfDoors;
            }

            set
            {
                this.m_NumOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
 @"{0}
Number of doors: {1}
Car color: {2}
"
,
            base.ToString(), this.m_NumOfDoors, this.m_Color);
        }
    }
}