using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class DisplayLicenseNumbers
    {
        public static void GetLicenseNumberLists(GarageLogic.GarageSystem io_VehicleList)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            List<string> licenseNumbersList = new List<string>();
            Console.WriteLine(
@"Please enter the kind of list you want to see
1. All license numbers
2. Filter by vehicle status");
            string kindOfList = Console.ReadLine();
            int userInput = 0;
            int.TryParse(kindOfList, out userInput);
            while (userInput < 1 || userInput > 2)
            {
                Console.WriteLine("Please enter a valid option");
                kindOfList = Console.ReadLine();
                int.TryParse(kindOfList, out userInput);
            }

            if (userInput == 1)
            {
                licenseNumbersList = io_VehicleList.GetLicenseNumberList();
                PrintLicenseNumbersInGarage(licenseNumbersList);
            }
            else if (userInput == 2)
            {
                GarageLogic.eVehicleStatus result = GarageLogic.eVehicleStatus.Undefined;
                result = GetFilterStatus();
                licenseNumbersList = io_VehicleList.GetLicenseNumberListByVehicleStatus(result);
                PrintLicenseNumbersInGarage(licenseNumbersList);
            }

            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();
        }

        public static void PrintLicenseNumbersInGarage(List<string> i_licenseNumbersList)
        {
            if (!i_licenseNumbersList.Any())
            {
                Console.WriteLine("No vehicle to show");
            }
            else
            {
                Console.WriteLine("Vehicle list by license number:");
                Console.WriteLine("===============================");

                foreach (string licenseNumber in i_licenseNumbersList)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        public static GarageLogic.eVehicleStatus GetFilterStatus()
        {
            GarageLogic.eVehicleStatus result = GarageLogic.eVehicleStatus.Undefined;
            Console.WriteLine(
@"Please enter the filter status:
1. In repair
2. Repaired
3. Payed");
            string requestedStatus = Console.ReadLine();
            int userInput = 0;
            int.TryParse(requestedStatus, out userInput);
            while (userInput < 1 || userInput > (int)GarageLogic.eVehicleStatus.Undefined)
            {
                Console.WriteLine("Please enter a valid option between 1-{0}", (int)GarageLogic.eVehicleStatus.Undefined);
                requestedStatus = Console.ReadLine();
                int.TryParse(requestedStatus, out userInput);
            }

            result = (GarageLogic.eVehicleStatus)(userInput - 1);
            return result;
        }
    }
}