using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GarageSystem
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage;

        public GarageSystem()
        {
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();
        }

        public void InsertNewVehicle(Vehicle i_Vehicle)
        {
            if (IsVehicleInGarage(i_Vehicle.LicenseNumber))
            {
                throw new Exception("This vehicle is already in the garage");
            }

            string licenseNumber = i_Vehicle.LicenseNumber;
            m_VehiclesInGarage.Add(licenseNumber, i_Vehicle);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetLicenseNumberList()
        {
            List<string> licenseNumbersList = new List<string>();
            foreach (KeyValuePair<string, Vehicle> vehicle in this.m_VehiclesInGarage)
            {
                licenseNumbersList.Add(vehicle.Value.LicenseNumber);
            }

            return licenseNumbersList;
        }

        public List<string> GetLicenseNumberListByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNumbersList = new List<string>();
            foreach (KeyValuePair<string, Vehicle> vehicle in this.m_VehiclesInGarage)
            {
                if (vehicle.Value.VehicleStatus == i_VehicleStatus)
                {
                    licenseNumbersList.Add(vehicle.Value.LicenseNumber);
                }
            }

            return licenseNumbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("Vehicle is not in the garage");
            }

            m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_VehicleStatus;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("Vehicle is not in the garage");
            }

            foreach (Wheel wheel in m_VehiclesInGarage[i_LicenseNumber].Wheels)
            {
                wheel.inflateActionToMaximum();
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToRefuel)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("Vehicle is not in the garage");
            }

            if (m_VehiclesInGarage[i_LicenseNumber].Engine.GetType() != typeof(FuelEngine))
            {
                throw new Exception("The fuel type is not suitable for the vehicle");
            }

            ((FuelEngine)m_VehiclesInGarage[i_LicenseNumber].Engine).Refuel(i_FuelType, i_AmountToRefuel);
            m_VehiclesInGarage[i_LicenseNumber].RemainingEnergyPercentage = (m_VehiclesInGarage[i_LicenseNumber].Engine.CurrentEnergyAmount / m_VehiclesInGarage[i_LicenseNumber].Engine.MaximumEnergyCapacity) * 100;
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_TimeToCharge)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("Vehicle is not in the garage");
            }

            if (m_VehiclesInGarage[i_LicenseNumber].Engine.GetType() != typeof(ElectricEngine))
            {
                throw new Exception("The type of charging is not suitable for the vehicle!");
            }

            ((ElectricEngine)m_VehiclesInGarage[i_LicenseNumber].Engine).Charge(i_TimeToCharge);
            m_VehiclesInGarage[i_LicenseNumber].RemainingEnergyPercentage = (m_VehiclesInGarage[i_LicenseNumber].Engine.CurrentEnergyAmount / m_VehiclesInGarage[i_LicenseNumber].Engine.MaximumEnergyCapacity) * 100;
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("Vehicle is not in the garage");
            }

            return m_VehiclesInGarage[i_LicenseNumber].ToString();
        }
    }
}