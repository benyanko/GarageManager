using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class VehicleDetails
    {
        public static void DisplayVehicleDetails(GarageLogic.GarageSystem i_VehicleList)
        {
            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter license number:");
                string userInput = Console.ReadLine();
                string vehicleDetails = string.Empty;
                try
                {
                    vehicleDetails = i_VehicleList.GetVehicleDetails(userInput);
                    Console.WriteLine(vehicleDetails);
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
    }
}
