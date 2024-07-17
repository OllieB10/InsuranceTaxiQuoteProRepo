
namespace TaxiQuoteEngineUI.Utility
{
    public static class MinimumPremiumChecker
    {
        public static decimal CheckMinimumPremium(decimal netPremium, decimal minimumPremium)
        {
            if (netPremium > minimumPremium)
            {
                return netPremium;
            }
            else if (netPremium <= minimumPremium)
            {
                netPremium = minimumPremium;
                return netPremium;
            }
            else
            {
                return netPremium;
            }
        }
    }
}
