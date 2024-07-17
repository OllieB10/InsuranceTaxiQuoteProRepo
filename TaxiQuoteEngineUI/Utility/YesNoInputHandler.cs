
namespace TaxiQuoteEngineUI.Utility
{
    public static class YesNoInputHandler
    {
        public static string GetYesOrNoValue(string input)
        {
            input = ValidateUserInput.GetValidUserInput(input);

            string changedInput = input.ToLower();

            while (!changedInput.StartsWith("yes") && !changedInput.StartsWith("no"))
            {
                // Empty line
                Console.WriteLine();

                // Inform the user they must enter yes or no and nothing else.
                ProposerMessages.MessageUser("That is an invalid answer, please enter (Yes or No) followed by the enter key: ");
                changedInput = Console.ReadLine() ?? string.Empty;

                changedInput = changedInput.ToLower();

                //Check and exit if desired.
                ExitApplication.CheckAndExitIfRequested(changedInput);
            }

            //return the valid word of Yes or No.
            return changedInput;
        }

        public static bool ReturnTrueOrFalse(string input)
        {
            string yesOrNoValue = GetYesOrNoValue(input);

            if (yesOrNoValue.StartsWith("yes"))
            {
                return true;
            }
            else if (yesOrNoValue.StartsWith("no"))
            {
                return false;
            }
            else
            {
                return false;
            }           
        }
    }
}
