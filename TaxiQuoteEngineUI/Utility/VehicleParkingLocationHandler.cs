using DataAccess.Enums;

namespace TaxiQuoteEngineUI.Utility
{
    public static class VehicleParkingLocationHandler
    {
        public static ParkingLocations GetParkingLocationOvernight(bool isAtHome)
        {
            ParkingLocations parkingLocation;

            // If the vehicle is parked at home then determine if its on the drive, in a garage, car park etc.
            if (isAtHome)
            {
                Console.WriteLine();

                ProposerMessages.AskVehicleLocationOverNight();
                string vehicleLocationOvernightAnswer = Console.ReadLine() ?? string.Empty;

                vehicleLocationOvernightAnswer = ValidateUserInput.FormatInputString(vehicleLocationOvernightAnswer);

                return parkingLocation = VehicleInputDetails.GetValidParkingLocation(vehicleLocationOvernightAnswer);
            }
            // It must not be parked at home, therefore store other.
            else
            {
                // We dont bother asking for more information we just use Other.
                return parkingLocation = ParkingLocations.Other;
            }
        }
    }
}
