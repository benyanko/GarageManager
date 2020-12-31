using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_CurrentFuelInLiters, float i_MaxFuelInLiters) : base(i_CurrentFuelInLiters, i_MaxFuelInLiters)
        {
            this.r_FuelType = i_FuelType;
        }

        public void Refuel(eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            if (this.r_FuelType != i_FuelType)
            {
                throw new Exception("The fuel type is not suitable for vehicles");
            }
            else
            {
                RefillVehicleEnergy(i_AmountOfFuelToAdd);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Fuel type: {0} 
Current fuel amount: {1}
Maximum fuel capacity: {2}",
            this.r_FuelType, CurrentEnergyAmount, MaximumEnergyCapacity);
        }
    }
}