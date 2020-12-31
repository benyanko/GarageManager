using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ChargeElectricBasedVehicle
    {
        public static void ChargeVehicle(GarageLogic.GarageSystem io_VehicleList)
        {
            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter your license number");
                string licenseNumber = Console.ReadLine();
                Console.WriteLine("Please insert time of charching");
                string userInput = Console.ReadLine();
                float timeToCharge = 0;
                float.TryParse(userInput, out timeToCharge);
                try
                {
                    io_VehicleList.ChargeVehicle(licenseNumber, timeToCharge);
                    Console.WriteLine("Charging succeeded");
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