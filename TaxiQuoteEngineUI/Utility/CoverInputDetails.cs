using DataAccess.Enums;

namespace TaxiQuoteEngineUI.Utility
{
    public static class CoverInputDetails
    {
        private static bool CheckCoverType(CoverType coverType)
        {
            CoverType[] allowedCCoverTypes = { CoverType.Comprehensive, CoverType.ThirdPartyFireAndTheft, CoverType.ThirdPartyOnly };

            return allowedCCoverTypes.Contains(coverType);
        }

        private static bool CheckNcdAmount(NCB ncb)
        {
            NCB[] allowedNcbs = { NCB.NewBadge, NCB.Zero, NCB.One, NCB.Two, NCB.Three, NCB.Four, NCB.Five, NCB.SixPlus };

            return allowedNcbs.Contains(ncb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static NCB GetNCDAmount(string input)
        {
            NCB ncb = new NCB();

            int ncbNumber = ValidateUserInput.GetValidInteger(input);

            if (ncbNumber >= 6)
            {
                ncb = NCB.SixPlus;
            }
            else if (ncbNumber == 0)
            {
                ncb = NCB.Zero;
            }
            else if (ncbNumber == 1)
            {
                ncb = NCB.One;
            }
            else if (ncbNumber == 2)
            {
                ncb = NCB.Two;
            }
            else if (ncbNumber == 3)
            {
                ncb = NCB.Three;
            }
            else if (ncbNumber == 4)
            {
                ncb = NCB.Four;
            }
            else if (ncbNumber == 5)
            {
                ncb = NCB.Five;
            }

            //if the user input is invalid then keep them looped until input is valid unless they choose to exit. 
            while (!Enum.TryParse(input, true, out ncb) || !CheckNcdAmount(ncb))
            {
                Console.WriteLine("You have entered an invalid NCB amount, it must not contain any special characters or must be  one of the amounts in the prior message, type exit to exit the application or type a valid legal owner to continue with the quote. ");

                input = Console.ReadLine() ?? string.Empty;

                //Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            return ncb;
        }

        public static CoverType GetCoverType(string input)
        {
            input = ValidateUserInput.FormatInputString(input);

            CoverType coverType;

            //if the user input is invalid then keep them looped until input is valid unless they choose to exit. 
            while (!Enum.TryParse(input, true, out coverType) || !CheckCoverType(coverType))
            {
                Console.WriteLine("You have entered an invalid cover type, please enter it again or type 'exit' to quit.");
                input = Console.ReadLine() ?? string.Empty;

                input = ValidateUserInput.FormatInputString(input);

                //Provide the user with the choice to exit.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            return coverType;
        }
    }
}
