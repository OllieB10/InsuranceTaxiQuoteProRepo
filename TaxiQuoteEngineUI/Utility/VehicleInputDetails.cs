﻿using DataAccess.Enums;

namespace TaxiQuoteEngineUI.Utility
{
    public static class VehicleInputDetails
    {

        private static bool CheckValidParkingOvernightLocation(ParkingLocations parkingLocation)
        {
            ParkingLocations[] allowedUses = { ParkingLocations.Carpark, ParkingLocations.Garage, ParkingLocations.Driveway, ParkingLocations.Street, ParkingLocations.Other};

            return allowedUses.Contains(parkingLocation);
        }

        private static bool CheckValidVehicleUse(VehicleUse vehicleUse)
        {
            VehicleUse[] allowedUses = { VehicleUse.PublicHire, VehicleUse.PrivateHire, VehicleUse.Other };

            return allowedUses.Contains(vehicleUse);
        }

        public static VehicleUse GetVehicleUsage(string input)
        {
            input = ValidateUserInput.GetValidUserInput(input);

            VehicleUse vehicleUse;

            if (input.StartsWith("Public"))
            {
                input = "PublicHire";
            }
            else if (input.StartsWith("Private"))
            {
                input = "PrivateHire";
            }
            else if (input.StartsWith("Other"))
            {
                input = "Other";
            }

            //if the user input is invalid then keep them looped until the input is valid unless they choose to exit. 
            while (!Enum.TryParse(input, true, out vehicleUse) && CheckValidVehicleUse(vehicleUse))
            {
                Console.WriteLine();

                Console.WriteLine("You have entered an invalid vehicle usage, it must not contain any special characters or must be one of the vehicle uses in the prior message, type exit to exit the application or type a valid vehicle use to continue with the quote. ");

                input = Console.ReadLine();

                //Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            return vehicleUse;
        }

        private static bool CheckValidVehicleTransmission(VehicleTransmission vehicleTransmission)
        {
            VehicleTransmission[] allowedTransmissions = { VehicleTransmission.Automatic, VehicleTransmission.Manual};

            return allowedTransmissions.Contains(vehicleTransmission);
        }

        public static VehicleTransmission GetValidVehicleTransmission(string input)
        {
            input = ValidateUserInput.GetValidUserInput(input);

            VehicleTransmission vehicleTransmissions;

            //if the user input is invalid then keep them looped until input is valid unless they choose to exit. 
            while (!Enum.TryParse(input, true, out vehicleTransmissions) && CheckValidVehicleTransmission(vehicleTransmissions))
            {
                Console.WriteLine();

                Console.WriteLine("You have entered an invalid vehicle usage, it must not contain any special characters or must be one of the vehicle uses in the prior message, type 'exit' to quit the application or type a valid vehicle use to continue with your quote. ");

                input = Console.ReadLine();

                //Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);                      
            }

            return vehicleTransmissions;
        }

        public static ParkingLocations GetValidParkingLocation(string input)
        {
            ParkingLocations parkingLocations;

            //if the user input is invalid then keep them looped until input is valid unless they choose to exit. 
            while (!Enum.TryParse(input, true, out parkingLocations) && CheckValidParkingOvernightLocation(parkingLocations))
            {
                Console.WriteLine("You have entered an invalid vehicle usage, it must not contain any special characters or must be one of the vehicle uses in the prior message, type exit to exit the application or type a valid vehicle use to continue with the quote. ");

                input = Console.ReadLine() ?? string.Empty;

                //Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            return parkingLocations;
        }

        public static bool CheckNumberOfSeats(string input)
        {
            if (!int.TryParse(input, out int numberOfSeats))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int GetNumberOfSeats(string input)
        {
            int numberOfSeats = 0;

            int result = 0;

            if (CheckNumberOfSeats(input))
            {
                int.TryParse(input, out int vehicleSeats);
                result = vehicleSeats;  // Assign the value before the condition check

                if (result >= 5 && result <= 9)
                {
                    return result;  // Return the valid result immediately
                }
            }

            // Use the logical AND operator instead of logical OR in the while loop condition
            while (!CheckNumberOfSeats(input) || result < 5 || result > 9)
            {
                Console.WriteLine();

                // Ask the user again for valid input.
                Console.WriteLine("You have entered an invalid number of seats, please enter a number from 1 to 9 or type 'exit' to exit the application.");

                input = Console.ReadLine();

                // Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);

                // if we can parse the input to an int and the value is within our parameters then return the number.
                if (int.TryParse(input, out numberOfSeats) && numberOfSeats >= 1 && numberOfSeats <= 16)
                {
                    return numberOfSeats; // Valid input, exit the loop.
                }

                // Assign the parsed value to result
                result = numberOfSeats;
            }

            // Return the number of seats
            return numberOfSeats;
        }

        public static bool CheckEstimatedVehicleValue(string input)
        {
            if (!decimal.TryParse(input, out decimal vehicleValue))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static decimal GetEstimatedVehicleValue(string input)
        {
            if (input.StartsWith("£"))
            {
                input = input.Replace("£", "");
            }

            while (!CheckEstimatedVehicleValue(input))
            {
                Console.WriteLine();

                Console.WriteLine("You have entered an invalid estimated vehicle value, enter the value again or type 'exit' to exit the application.");
                input = Console.ReadLine();

                //Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            decimal.TryParse(input, out decimal result);

            return result;
        }
    }
}
