using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_RemainingTimeOfEngine, float i_MaxTimeOfEngine) : base(i_RemainingTimeOfEngine, i_MaxTimeOfEngine)
        {
        }

        public void Charge(float i_HoursToAddForBattery)
        {
            RefillVehicleEnergy(i_HoursToAddForBattery);
        }

        public override string ToString()
        {
            return string.Format(
@"Current battery energy: {0}
Maximum battery life: {1}",
            CurrentEnergyAmount, MaximumEnergyCapacity);
        }
    }
}