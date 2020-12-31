using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Engine
    {
        private readonly float r_MaximumEnergyCapacity;
        private float m_CurrentEnergyAmount;
        private string m_ErrorMessage;

        protected Engine(float i_CurrentEnergyAmount, float i_MaximumEnergyCapacity)
        {
            if (i_CurrentEnergyAmount > i_MaximumEnergyCapacity || i_CurrentEnergyAmount <= 0)
            {
                m_ErrorMessage = string.Format("Invalid engine energy amount. Please insert the amount in the range 0 - {0}", i_MaximumEnergyCapacity);
                throw new ValueOutOfRangeException(0.0f, i_MaximumEnergyCapacity, m_ErrorMessage);
            }
            else
            {
                this.m_CurrentEnergyAmount = i_CurrentEnergyAmount;
                this.r_MaximumEnergyCapacity = i_MaximumEnergyCapacity;
            }
        }

        public float CurrentEnergyAmount
        {
            get
            {
                return this.m_CurrentEnergyAmount;
            }

            set
            {
                this.m_CurrentEnergyAmount = CheckEnergyInput(value);
            }
        }

        public float MaximumEnergyCapacity
        {
            get
            {
                return this.r_MaximumEnergyCapacity;
            }
        }

        private float CheckEnergyInput(float i_EnergyInput)
        {
            if (i_EnergyInput > this.r_MaximumEnergyCapacity || i_EnergyInput <= 0)
            {
                m_ErrorMessage = string.Format("Invalid energy amount. Please insert the amount in the range 0 - {0}", r_MaximumEnergyCapacity);
                throw new ValueOutOfRangeException(0.0f, this.r_MaximumEnergyCapacity, m_ErrorMessage);
            }
            else
            {
                return i_EnergyInput;
            }
        }

        public void RefillVehicleEnergy(float i_AmountOfFuelToAdd)
        {
            if (i_AmountOfFuelToAdd + this.m_CurrentEnergyAmount > this.r_MaximumEnergyCapacity || i_AmountOfFuelToAdd <= 0)
            {
                m_ErrorMessage = string.Format("Invalid energy amount. Please insert the amount in the range 0 - {0}", this.r_MaximumEnergyCapacity - this.m_CurrentEnergyAmount);
                throw new ValueOutOfRangeException(0, this.r_MaximumEnergyCapacity - this.m_CurrentEnergyAmount, m_ErrorMessage);
            }
            else
            {
                this.m_CurrentEnergyAmount += i_AmountOfFuelToAdd;
            }
        }
    }
}