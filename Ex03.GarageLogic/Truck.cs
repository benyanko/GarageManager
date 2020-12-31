using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly int r_NumOfWheels = 16;
        private readonly float m_MaximumWheelsAirPressure = 28;
        private readonly eFuelType r_FuelType = eFuelType.Soler;
        private readonly float r_MaximumFuelCapacity = 120;
        private bool m_IsContainsDangerousMaterials;
        private float m_VolumeOfCargo;

        public Truck(float i_CurrentFuelInLiters, float i_CurrentWheelsAirPressure)
        {
            this.m_IsContainsDangerousMaterials = false;
            this.m_VolumeOfCargo = 0;
            Wheels = new List<Wheel>(this.r_NumOfWheels);
            for (int i = 0; i < this.r_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(this.m_MaximumWheelsAirPressure, i_CurrentWheelsAirPressure);
                Wheels.Add(wheel);
            }

            Engine = new FuelEngine(r_FuelType, i_CurrentFuelInLiters, this.r_MaximumFuelCapacity);
            RemainingEnergyPercentage = (Engine.CurrentEnergyAmount / r_MaximumFuelCapacity) * 100;
        }

        public bool IsContainsDangerousMaterials
        {
            get
            {
                return m_IsContainsDangerousMaterials;
            }

            set
            {
                m_IsContainsDangerousMaterials = value;
            }
        }

        public float VolumeOfCargo
        {
            get
            {
                return m_VolumeOfCargo;
            }

            set
            {
                m_VolumeOfCargo = value;
            }
        }

        public void Refuel(eFuelType i_FuelType, float i_AmountToRefuel)
        {
            ((FuelEngine)Engine).Refuel(i_FuelType, i_AmountToRefuel);
            RemainingEnergyPercentage = (Engine.CurrentEnergyAmount / this.r_MaximumFuelCapacity) * 100;
        }

        public override string ToString()
        {
            if (m_IsContainsDangerousMaterials)
            {
                return string.Format(
@"{0}
Truck is carrying dangerous materials
Volume Of Cargo: {1}
",
                base.ToString(), this.m_VolumeOfCargo);
            }
            else
            {
                return string.Format(
@"{0}
Truck is not carrying dangerous materials
Volume Of Cargo: {1}
",
                base.ToString(), this.m_VolumeOfCargo);
            }
        }
    }
}