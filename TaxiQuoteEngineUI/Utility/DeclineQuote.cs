
namespace TaxiQuoteEngineUI.Utility
{
    public static class DeclineQuote
    {
        
        public static void Decline(string message)
        {
            Console.WriteLine(message);

            Console.ReadLine();

            ExitApplication.Exit();
        }
    }
}
