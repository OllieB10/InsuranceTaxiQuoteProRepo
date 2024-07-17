using System.Globalization;

namespace TaxiQuoteEngineUI.Utility
{
    public static class DateFormats
    {
        /// <summary>
        /// Ensures the user enteres only valid year formats.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int GetYear(string year)
        {
            while (!CheckValidYear(year))
            {
                // Ask the user again to enter the year of manufacture.
                Console.WriteLine("The year you entered is not valid, can you please enter another date.");

                // Read the users answer
                year = Console.ReadLine();

                // Provide the user with a way to exit the application if desired.
                ExitApplication.CheckAndExitIfRequested(year);
            }

            //Convert the string year to a datetime.
            int.TryParse(year, out int yearOut);

            //return the year as a datetime.
            return yearOut;
        }

        /// <summary>
        /// Ensures the user enteres only valid year formats.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int GetMonth(string year)
        {
            while (!CheckValidYear(year))
            {
                // Ask the user again to enter the year of manufacture.
                Console.WriteLine("The month you entered is not valid, can you please enter another date.");

                // Read the users answer
                year = Console.ReadLine();

                // Provide the user with a way to exit the application if desired.
                ExitApplication.CheckAndExitIfRequested(year);
            }
            //Convert the string year to a datetime.
            int.TryParse(year, out int yearOut);

            //return the year as a datetime.
            return yearOut;
        }

        /// <summary>
        /// Check if the DOB is valid based on whether we can parse it to a datetime.
        /// </summary>
        /// <param name="dob"></param>
        /// <returns></returns>
        public static bool CheckValidDateFormat(string date)
        {
            // Get the various legitimate date formats.
            string dateFormat = "ddMMyyyy";

            //If we can parse exact the date of birth return true.
            if (DateTime.TryParseExact(date, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                //We parsed all the dates.
                return true;
            }

            //Cannot parse the dates.
            return false;
        }

        public static bool CheckValidYear(string year)
        {
            // Check if the input string is a 4-digit number
            if (year.Length != 4)
                return false;

            // Check if all characters in the string are digits
            foreach (char c in year)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            // Convert the string to an integer and check if it's in a reasonable range (e.g., between 1900 and the current year)
            if (int.TryParse(year, out int yearNumber) && yearNumber >= 1900 && yearNumber <= DateTime.Now.Year)
                return true;

            return false;
        }

        public static DateTime GetValidDate(string date)
        {
            while (!CheckValidDateFormat(date))
            {
                Console.WriteLine();

                Console.WriteLine("The date you have entered is invalid, please enter it again using the format 'ddMMyyyy' or type 'exit' to exit the application.");
                date = Console.ReadLine();

                //Check and exit the application if desired.
                ExitApplication.CheckAndExitIfRequested(date);
            }

            // If the while loop exits, it means a valid date was entered.
            DateTime.TryParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOut);

            return dateOut;
        }
    }
}
