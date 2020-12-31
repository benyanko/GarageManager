using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ChangeCertianVehicleStatus
    {
        public static void ChangeVehicleStatus(GarageLogic.GarageSystem io_VehicleList)
        {
            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                GarageLogic.eVehicleStatus requiredVehicleStatus = GarageLogic.eVehicleStatus.Undefined;
                Console.WriteLine("Please enter your license number");
                string licenseNumber = Console.ReadLine();
                Console.WriteLine(
    @"Please enter the new status you want to change the vehicle
1. In repair
2. Repaired
3. Payed");
                string requestedStatus = Console.ReadLine();
                int userInput = 0;
                int.TryParse(requestedStatus, out userInput);
                while (userInput < 0 || userInput > (int)GarageLogic.eVehicleStatus.Undefined)
                {
                    Console.WriteLine("Please enter a valid option between 1-{0}", (int)GarageLogic.eVehicleStatus.Undefined);
                    requestedStatus = Console.ReadLine();
                    int.TryParse(requestedStatus, out userInput);
                }

                requiredVehicleStatus = (GarageLogic.eVehicleStatus)(userInput - 1);
                try
                {
                    io_VehicleList.ChangeVehicleStatus(licenseNumber, requiredVehicleStatus);
                    Console.WriteLine("Status change succeeded");
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