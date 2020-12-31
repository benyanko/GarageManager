using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class InflateWheelsToMaximum
    {
        public static void InflateWheelsToMax(GarageLogic.GarageSystem io_VehicleList)
        {
            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter your license number:");
                string licenseNumber = Console.ReadLine();
                try
                {
                    io_VehicleList.InflateWheelsToMax(licenseNumber);
                    Console.WriteLine("Inflate wheels succeeded");
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