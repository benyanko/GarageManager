using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace Ex03.ConsoleUI
{
    public class RefuelFuelBasedVehicle
    {
        public static void RefuelVehicle(GarageLogic.GarageSystem io_VehicleList)
        {
            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                GarageLogic.eFuelType fuelType = GarageLogic.eFuelType.Undefined;
                Console.WriteLine("Please enter your license number");
                string licenseNumber = Console.ReadLine();
                fuelType = GetFuelType();
                Console.WriteLine("Please insert to amount of fuel you want to add");
                string userInput = Console.ReadLine();
                float amountToAdd = 0;
                float.TryParse(userInput, out amountToAdd);
                try
                {
                    io_VehicleList.RefuelVehicle(licenseNumber, fuelType, amountToAdd);
                    Console.WriteLine("Refuel succeeded");
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
        }

        public static GarageLogic.eFuelType GetFuelType()
        {
            GarageLogic.eFuelType resultFuelType = GarageLogic.eFuelType.Undefined;
            Console.WriteLine(
@"Please enter your vehcile fuel type
1. Soler,
2. Octan95,
3. Octan96,
4. Octan98");

            string fuelType = Console.ReadLine();
            int userInput = 0;
            int.TryParse(fuelType, out userInput);
            while (userInput < 1 || userInput > (int)eFuelType.Undefined)
            {
Console.WriteLine(
@"This fuel type doesn't match to any fuel type in the garage,
please insert a valid fuel type");
                fuelType = Console.ReadLine();
                int.TryParse(fuelType, out userInput);
            }

            resultFuelType = (eFuelType)(userInput - 1);
            
            return resultFuelType;
        }
    }
}