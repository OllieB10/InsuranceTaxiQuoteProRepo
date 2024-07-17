namespace TaxiQuoteEngineUI.Utility
{
    public static class ExitApplication
    {
        //Exits the application.
        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void CheckAndExitIfRequested(string userInput)
        {
            if (userInput.ToLower() == "exit")
            {
                Exit();
            }
        }
    }
}
