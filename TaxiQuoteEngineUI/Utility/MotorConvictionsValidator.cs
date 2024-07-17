
namespace TaxiQuoteEngineUI.Utility
{
    public static class MotorConvictionsValidator
    {
        public static bool CheckMotoringConvictionsValidValue(string usersAnswer)
        {
            if (usersAnswer.Length != 1)
                return false;

            bool isParsed = int.TryParse(usersAnswer, out int key);

            if (!isParsed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int ConvertUsersMotoringConvictions(string usersAnswer)
        {
            while (!CheckMotoringConvictionsValidValue(usersAnswer))
            {
                Console.WriteLine($"The value you entered is invalid, please choose a number next to" +
                                                   "the Criminal Conviction or enter 0 if you have no criminal convictions or enter 9" +
                                                           "if it isnt an option. ");

                usersAnswer = Console.ReadLine() ?? string.Empty;

                if (usersAnswer.ToLower() == "exit")
                {
                    ExitApplication.Exit();
                }
            }

            int crimKey = int.Parse(usersAnswer);

            return crimKey;
        }

        public static string MotoringConvictions(int usersAnswer)
        {
            // Define our criminal convictions and the keys to get them
            var crimConvicValues = new Dictionary<int, string>
            {
                { 1,"MURDER"},
                { 2, "ATTEMPTED MURDER"},
                { 3, "MANSLAUGHTER"},
                { 4, "RAPE"},
                { 5, "KIDNAPPING"},
                { 6, "GROSS INDECENCY"},
                { 7, "DEATH BY RECKLESS DRIVING"},
                { 8, "FIREARMS OFFENCES"},
                { 9, "None"},
                { 0, "Other"}
            };

            bool gotValue = crimConvicValues.TryGetValue(usersAnswer, out string criminalConviction);

            if (!gotValue)
            {
                return string.Empty;
            }
            else
            {
                return criminalConviction;
            }
        }

        public static string GetMotorConvictionType(int crimConvicCode)
        {
            string? usersCrimConviction = MotoringConvictions(crimConvicCode);

            return usersCrimConviction;
        }
    }
}
