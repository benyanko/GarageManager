using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class Menu
    {
        public static void Start()
        {
            int userChoice = 0;
            GarageLogic.GarageSystem vehicleList = new GarageLogic.GarageSystem();
            while(userChoice != 8)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(
@"Welcome to Ben & Yuval garage 
================================
1. Insert new vehicle
2. Display vehicle list by license number
3. Change vehicle’s status
4. Inflate wheels to maximum
5. Refuel a fuel-based vehicle
6. Charge an electric-based vehicle
7. Display vehicle information 
8. Exit");
                string userInput = Console.ReadLine();
                userChoice = 0;
                int.TryParse(userInput, out userChoice);
                while(userChoice < 1 || userChoice > 8)
                {
                    Console.WriteLine("Invaild input");
                    userInput = Console.ReadLine();
                    int.TryParse(userInput, out userChoice);
                }

                if (userChoice == 1)
                {
                    InsertNewVehicle.NewVehicle(vehicleList);
                }

                if (userChoice == 2)
                {
                    DisplayLicenseNumbers.GetLicenseNumberLists(vehicleList);
                }

                if (userChoice == 3)
                {
                    ChangeCertianVehicleStatus.ChangeVehicleStatus(vehicleList);
                }

                if (userChoice == 4)
                {
                    InflateWheelsToMaximum.InflateWheelsToMax(vehicleList);
                }

                if (userChoice == 5)
                {
                    RefuelFuelBasedVehicle.RefuelVehicle(vehicleList);
                }

                if (userChoice == 6)
                {
                    ChargeElectricBasedVehicle.ChargeVehicle(vehicleList);
                }

                if (userChoice == 7)
                {
                    VehicleDetails.DisplayVehicleDetails(vehicleList);
                } 
            }  
        }
    }
}
