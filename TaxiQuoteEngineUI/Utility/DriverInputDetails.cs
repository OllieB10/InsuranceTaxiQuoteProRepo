using DataAccess.Enums;

namespace TaxiQuoteEngineUI.Utility
{
    public static class DriverInputDetails
    {
        private static bool CheckValidIncidentType(IncidentType incidentType)
        {
            IncidentType[] allowedIncidents = { IncidentType.Other, IncidentType.Accident };

            return allowedIncidents.Contains(incidentType);
        }

        public static IncidentType GetValidIncidentType(string input)
        {
            input = ValidateUserInput.GetValidUserInput(input);

            IncidentType incidentType;

            //if the user input is invalid then keep them looped until input is valid unless they choose to exit. 
            while (!Enum.TryParse(input, true, out incidentType) && CheckValidIncidentType(incidentType))
            {
                //Inform the user they have entered an invalid incident type and display them again.
                Console.WriteLine("You have entered an invalid incident type, it must not contain any special characters or must be either 'Accident' or 'Other', type exit to exit the application or type a valid vehicle use to continue with the quote. ");

                input = Console.ReadLine();

                ExitApplication.CheckAndExitIfRequested(input);
            }

            return incidentType;
        }

        public static DriverAges GetDriverAgeEnum(int yearAtInception)
        {
            DriverAges driverAge = new DriverAges();

            if (yearAtInception >= 70)
            {
                driverAge = DriverAges.SeventyPlus;
            }
            else if (yearAtInception >= 25 && yearAtInception < 30)
            {
                driverAge = DriverAges.TwentyFiveToTwentyNine;
            }
            else if (yearAtInception >= 30 && yearAtInception < 35)
            {
                driverAge = DriverAges.ThirtyToThirtyFour;
            }
            else if (yearAtInception >= 35 && yearAtInception < 40)
            {
                driverAge = DriverAges.ThirtyFiveToThirtyNine;
            }
            else if (yearAtInception >= 40 && yearAtInception < 45)
            {
                driverAge = DriverAges.FortyToFortyFour;
            }
            else if (yearAtInception >= 45 && yearAtInception < 50)
            {
                driverAge = DriverAges.FortyFiveToFortyNine;
            }
            else if (yearAtInception >= 50 && yearAtInception < 70)
            {
                driverAge = DriverAges.FiftyToSixtyNine;
            }

            return driverAge;
        }
    }
}
