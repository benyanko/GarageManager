using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class FuelBasedMotocycle : Motocycle
    {
        private readonly eFuelType r_FuelType = eFuelType.Octan95;
        private readonly float r_MaximumFuelCapacity = 7;

        public FuelBasedMotocycle(float i_CurrentFuelInLiters, float i_CurrentAirPressure) : base(i_CurrentAirPressure)
        {
            Engine = new FuelEngine(this.r_FuelType, i_CurrentFuelInLiters, this.r_MaximumFuelCapacity);
            RemainingEnergyPercentage = (Engine.CurrentEnergyAmount / r_MaximumFuelCapacity) * 100;
        }

        public void Refuel(eFuelType i_FuelType, float i_AmountToRefuel)
        {
            ((FuelEngine)Engine).Refuel(i_FuelType, i_AmountToRefuel);
            RemainingEnergyPercentage = (Engine.CurrentEnergyAmount / this.r_MaximumFuelCapacity) * (float)100.0;
        }

        public override string ToString()
        {
            return string.Format("{0}", base.ToString());
        }
    }
}