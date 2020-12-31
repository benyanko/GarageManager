using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class InsertNewVehicle
    {
        public static void NewVehicle(GarageLogic.GarageSystem io_VehicleList)
        {
            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter owner name:");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please enter owner phone number:");
                string ownerPhoneNumber = Console.ReadLine();
                Console.WriteLine("Please enter license number:");
                string licenseNumber = Console.ReadLine();
                GarageLogic.eTypesOfVehcile VehicleType = GetVehicleType();
                Console.WriteLine("Please enter model name:");
                string modelName = Console.ReadLine();
                float CurrentEnergyAmount = GetCurrentEnergyAmount(VehicleType);
                float CurrentAirPressure = GetCurrentAirPressure(VehicleType);
                try
                {
                    GarageLogic.Vehicle vehicle = GarageLogic.CreateVehicle.VehiclesBuilder(VehicleType, CurrentEnergyAmount, CurrentAirPressure);
                    Console.WriteLine("Please enter wheel manufacturer name:");
                    string manufacturerName = Console.ReadLine();
                    SetWheelManufacturerName(vehicle, manufacturerName);
                    vehicle.OwnerName = ownerName;
                    vehicle.OwnerPhoneNumber = ownerPhoneNumber;
                    vehicle.LicenseNumber = licenseNumber;
                    vehicle.ModelName = modelName;
                    SetSpecialDetails(vehicle, VehicleType);
                    try
                    {
                        io_VehicleList.InsertNewVehicle(vehicle);
                        Console.WriteLine("The vehicle entered the garage successfully");
                        Console.WriteLine("Press enter to go back to menu");
                        Console.ReadLine();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press enter to try again");
                    Console.ReadLine();
                }
            }
        }

        private static GarageLogic.eTypesOfVehcile GetVehicleType()
        {
            GarageLogic.eTypesOfVehcile VehicleType = GarageLogic.eTypesOfVehcile.Undefined;
            
            Console.WriteLine(
@"Please select the vehicle type
1. Fuel-Based Motorcycle
2. Electric Motorcycle
3. Fuel-Based Car
4. Electric Car
5. Fuel-Based Truck");

            string userInput = Console.ReadLine();
            int userChoise = 0;
            int.TryParse(userInput, out userChoise);
            while(userChoise < 1 || userChoise > (int)eTypesOfVehcile.Undefined)
            {
                Console.WriteLine("Invaild input, please insert input betwin 1-{0}", (int)eTypesOfVehcile.Undefined);
                userInput = Console.ReadLine();
                int.TryParse(userInput, out userChoise);
            }

            VehicleType = (GarageLogic.eTypesOfVehcile)(userChoise - 1);
            return VehicleType;
        }

        private static float GetCurrentEnergyAmount(GarageLogic.eTypesOfVehcile i_VehicleType)
        {
            float currentEnergyAmount = 0;
            Console.WriteLine("Please insert current engine energy amount:");
            string userInput = Console.ReadLine();
            float.TryParse(userInput, out currentEnergyAmount);
            return (float)currentEnergyAmount;
        }

        private static float GetCurrentAirPressure(GarageLogic.eTypesOfVehcile i_VehicleType)
        {
            float CurrentAirPressure = 0;
            string userInput = string.Empty;
            Console.WriteLine("Please insert current wheel air pressure:");
            userInput = Console.ReadLine();
            float.TryParse(userInput, out CurrentAirPressure);
            return CurrentAirPressure;
        }

        public static void SetWheelManufacturerName(GarageLogic.Vehicle io_vehicle, string i_ManufacturerName)
        {
            foreach (GarageLogic.Wheel wheel in io_vehicle.Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public static void SetSpecialDetails(GarageLogic.Vehicle io_vehicle, GarageLogic.eTypesOfVehcile i_VehicleType)
        {
            if (i_VehicleType == GarageLogic.eTypesOfVehcile.FuelBasedMotorcycle ||
              i_VehicleType == GarageLogic.eTypesOfVehcile.ElectricMotorcycle)
            {
                SetMotorcycleDetails(io_vehicle);
            }
            else if (i_VehicleType == GarageLogic.eTypesOfVehcile.FuelBasedCar ||
                i_VehicleType == GarageLogic.eTypesOfVehcile.ElectricCar)
            {
                SetCarDetails(io_vehicle);
            }
            else if (i_VehicleType == GarageLogic.eTypesOfVehcile.Truck)
            {
                SetTruckDetails(io_vehicle);
            }
        }

        private static void SetMotorcycleDetails(GarageLogic.Vehicle io_vehicle)
        {
            Console.WriteLine(
            @"Please select License Type
1. A
2. A1
3. AA
4. B");
            string userInput = Console.ReadLine();
            int userChoice = 0;
            int.TryParse(userInput, out userChoice);
            while (userChoice < 1 || userChoice > (int)eLicenseType.Undefind)
            {
                Console.WriteLine("Invaild input, please insert input between 1-{0}", (int)eLicenseType.Undefind);
                userInput = Console.ReadLine();
                int.TryParse(userInput, out userChoice);
            }

            (io_vehicle as Motocycle).LicenseType = (eLicenseType)(userChoice - 1);
            Console.WriteLine("Please insert motocycle engine volume");
            int engineVolume = 0;
            userInput = Console.ReadLine();
            int.TryParse(userInput, out engineVolume);
            while (engineVolume <= 0)
            {
                Console.WriteLine("Invalid engine volume");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out engineVolume);
            }

            (io_vehicle as Motocycle).EngineVolume = userChoice;
        }

        private static void SetCarDetails(GarageLogic.Vehicle io_vehicle)
        {
            string userInput = string.Empty;
            int userChoice = 0;
            Console.WriteLine(
            @"Please select the car color
1. Red
2. White
3. Black
4. Silver");
            userInput = Console.ReadLine();
            int.TryParse(userInput, out userChoice); 
            while (userChoice < 1 || userChoice > (int)eColor.Undefined)
            {
                Console.WriteLine("Invaild input, please insert input betwin 1-{0}", (int)eColor.Undefined);
                userInput = Console.ReadLine();
                int.TryParse(userInput, out userChoice);
            }

            (io_vehicle as Car).Color = (eColor)(userChoice - 1);
           
            Console.WriteLine(
           @"Please select number of doors in car
1. Two
2. Three
3. Four
4. Five");
            userInput = Console.ReadLine();
            int.TryParse(userInput, out userChoice);
            while (userChoice < 1 || userChoice > (int)eNumOfDoors.Undefined)
            {
                Console.WriteLine("Invaild input, please insert input betwin 1-{0}", (int)eNumOfDoors.Undefined);
                userInput = Console.ReadLine();
                int.TryParse(userInput, out userChoice);
            }

            (io_vehicle as Car).NumberOfDoors = (eNumOfDoors)(userChoice - 1);
        }

        private static void SetTruckDetails(GarageLogic.Vehicle io_vehicle)
        {
            string userInput = string.Empty;
            int userChoice = 0;
            Console.WriteLine(
@"Is the truck contains dangerous materials?
1. Yes
2. No");

            userInput = Console.ReadLine();
            int.TryParse(userInput, out userChoice);
            while (userChoice < 1 || userChoice > 2)
            {
                Console.WriteLine("Invaild input, please insert input betwin 1-2");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out userChoice);
            }

            if (userChoice == 1)
            {
                (io_vehicle as Truck).IsContainsDangerousMaterials = true;
            }
            else
            {
                (io_vehicle as Truck).IsContainsDangerousMaterials = false;
            }

            Console.WriteLine("Please insert truck volume of carg");
            float volumeOfCargo = 0;
            userInput = Console.ReadLine();
            float.TryParse(userInput, out volumeOfCargo);
            while (volumeOfCargo <= 0)
            {
                Console.WriteLine("Invalid engine volume");
                userInput = Console.ReadLine();
                float.TryParse(userInput, out volumeOfCargo);
            } 

            (io_vehicle as Truck).VolumeOfCargo = volumeOfCargo;
        }
    }
}
