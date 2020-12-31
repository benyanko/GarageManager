using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public static class CreateVehicle
    {
        public static Vehicle VehiclesBuilder(eTypesOfVehcile i_VehicleType, float i_CurrentEnergyAmount, float i_CurrentAirPressure)
        {
            Vehicle vehicle;
            if (i_VehicleType == eTypesOfVehcile.FuelBasedCar)
            {
                vehicle = new FuelBasedCar(i_CurrentEnergyAmount, i_CurrentAirPressure);
            }
            else if (i_VehicleType == eTypesOfVehcile.ElectricCar)
            {
                vehicle = new ElectricCar(i_CurrentEnergyAmount, i_CurrentAirPressure);
            }
            else if (i_VehicleType == eTypesOfVehcile.FuelBasedMotorcycle)
            {
                vehicle = new FuelBasedMotocycle(i_CurrentEnergyAmount, i_CurrentAirPressure);
            }
            else if (i_VehicleType == eTypesOfVehcile.ElectricMotorcycle)
            {
                vehicle = new ElectricMotocycle(i_CurrentEnergyAmount, i_CurrentAirPressure);
            }
            else if (i_VehicleType == eTypesOfVehcile.Truck)
            {
                vehicle = new Truck(i_CurrentEnergyAmount, i_CurrentAirPressure);
            }
            else
            {
                throw new Exception("Unknown vehicle for our garage");
            }

            return vehicle;
        }
    }
}