
namespace TaxiQuoteEngineUI.Utility
{
    /// <summary>
    /// Question for each class to answer is....
    /// S....does it have a single responsibility? Yes, this class as it print messages to the user, its single responsibility is to print messages to the user,
    /// O.... Is it Open for extension but closed for modification? 
    /// L.... Is theclass abide by liskov substitu
    /// does it have 1 reason to change? yes, if we need to add a new message it does not impact any other code.
    /// 
    /// </summary>
    public static class ProposerMessages
    {

        #region Welcome Customer
        /// <summary>
        /// Welcome the user.
        /// </summary>
        public static void WelcomeUser()
        {
            //Completed and ready for testing.
            Console.Write("Welcome to the site, lets get started on your Taxi insurance quote.");
        }

        #endregion

        #region Personal Questions

        //Write messages to the user.
        public static void MessageUser(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Ask the user for their first name.
        /// </summary>
        public static void AskFirstName()
        {
            //Completed and ready for testing.
            Console.Write($"Please enter your first name: ");
        }

        /// <summary>
        /// Ask the user for their last name.
        /// </summary>
        public static void AskLastName()
        {
            //Completed and ready for testing.
            Console.Write("Please enter your last name: ");
        }

        /// <summary>
        /// Ask the proposer for their date of birth.
        /// </summary>
        public static void AskDateOfBirth()
        {
            //Completed and ready for testing.
            Console.Write("Please enter your date of birth: ");
        }

        /// <summary>
        /// Ask the proposer what their gender is.
        /// </summary>
        public static void AskGender()
        {
            //Completed and ready for testing.
            Console.Write("Please enter your gender, Male, Female or Other: ");
        }
        /// <summary>
        /// Ask the proposer for their email address.
        /// </summary>
        public static void AskEmailAddress()
        {
            //Completed and ready for testing.
            Console.Write("Please enter your email address: ");
        }

        /// <summary>
        /// Ask proposer for relationship status
        /// </summary>
        public static void AskRelationshipStatus()
        {
            // Relationship Status
            Console.Write("Please choose from one of the following relationship statuses, Married, Single, Separated, Widowed, Diviorced or Living with Partner: ");
        }

        #endregion

        #region Driver Messages

        /// <summary>
        /// Ask the proposer if they have been a resident since birth.
        /// </summary>
        public static void AskResidentSinceBirth()
        {
            //Completed and ready for testing.
            Console.Write("Have you been a resident since birth? enter (Yes or No): ");
        }

        /// <summary>
        /// Ask the date the proposer has been a resident since, provide date formats for clarification.
        /// </summary>
        public static void AskDateResidentSince()
        {
            Console.Write("Enter the date you have been resident since: ");
        }

        public static void AskVehicleUsage()
        {
            Console.Write("How is the vehicle primarily used? Private Hire, Public Hire or Other: ");
        }

        public static void AskForPlatedCouncil()
        {
            Console.Write("What is the name of the council you are allowed to operate out of: ");
        }

        /// <summary>
        /// Ask the proposer for any criminal convictions.
        /// </summary>
        public static void AskAnyCriminalConvictions()
        {
            //Completed and ready for testing.
            Console.Write("Have you got any criminal convictions? enter (Yes or No): ");
        }

        public static void AskPreviouslyRefusedCover()
        {
            Console.Write("Have you ever previously been refused cover? enter (Yes or No): ");
        }

        public static void AskPreviouslyHadTermsApplied()
        {
            Console.Write("Have you ever had insurance terms applied? enter (Yes or No): ");
        }

        public static void AskVehicleKeptAtHomeOverNight()
        {
            Console.Write("Is the taxi kept at home overnight? enter (Yes or No): ");
        }

        public static void AskVehicleLocationOverNight()
        {
            Console.Write("Please choose from one of the following parking locations: Car Park, Garage, Driveway, Street: ");
        }

        #region Convictions Messages

        public static void AskAnyConvictions()
        {
            Console.Write("Have you had any driving related convictions, endorsements, penalties, disqualified, or bans in the past 5 years:  ");
        }

        public static void AskOffenceDate()
        {
            Console.Write("Enter the Offence Date: ");
        }

        public static void AskConvictionDate()
        {
            Console.Write("On what date were you convicted: ");
        }

        public static void AskDisqualifiedFromDriving()
        {
            Console.Write("Have you previously been disqualified from driving: ");
        }

        public static void AskForTotalPoints()
        {
            Console.Write("How many points did you get: ");
        }

        public static void AskAnyPointsGiven()
        {
            Console.Write("How many points did you get: ");
        }

        public static void AskForFineAmount()
        {
            Console.Write("How much was the fine you received: ");
        }

        public static void AskIfFineOccurred()
        {
            Console.Write("Did the conviction result in a fine: ");
        }

        public static void AskAnyCashPaymentsTaken()
        {
            Console.Write("Any cash payments taken in the taxi: ");
        }

        public static void AskForTheftType()
        {
            Console.Write("What type of theft? Theft, Theft of vehicle or Theft Related Damage: ");
        }

        public static void AskForDVLAOffenceCode()
        {
            Console.Write("What is the offical DVLA offence code/name: ");
        }

        public static void AskHowLongBannedFor()
        {
            Console.Write("How long were you banned for: ");
        }

        public static void AskHowManyMotorConvictions()
        {
            Console.Write("How many motoring convictions do you currently have: ");
        }

        #endregion

        #region Claims Messages

        public static void AskAnyMotorClaims()
        {
            Console.Write("Have there been any motor claims regardless of fault or whether a claim was filed (Yes or No): ");
        }

        public static void AskIncidentType()
        {
            Console.Write("Choose from the two types of incident: Accident or Other: ");
        }

        public static void AskAtFault()
        {
            Console.Write("Were you at fault for the accident? (Yes or No): ");
        }

        public static void AskForClaimDate()
        {
            Console.Write("What was the incident date? please provide the answer in this format (yyyy-MM-dd): ");
        }

        public static void AskClaimMadeAgainstPolicy()
        {
            Console.Write("Was the claim made against your taxi insurance policy: ");
        }

        public static void AskNoClaimsDiscountAffected()
        {
            Console.Write("Was your no claims discount affected: ");
        }

        public static void AskAnyMoreIncidents()
        {
            Console.Write("Have you had any more incidents in the past? (Yes or No): ");
        }

        #endregion

        #endregion

        #region Licence Details Messages

        public static void AskForLicenceType()
        {
            Console.Write($"What type of licence type do you have: ");
        }

        public static void AskDateCurrentLicenceObtained()
        {
            Console.Write($"Enter the date you obtained your current licence: ");
        }

        public static void AskWhetherHaveFullUkLicence()
        {
            Console.Write("Do you have a full UK car licence? (Yes/No): ");
        }

        #endregion

        #region Vehicle Messages

        public static void AskYearOfManufacture()
        {
            //Completed and ready for testing.
            Console.Write($"What year was the vehicle manufactured? Give me the answer in the followingg format ('yyyy' e.g 2017 or 1995): ");
        }

        public static void AskVehicleMileage()
        {
            Console.Write($"What is your annual mileage: ");
        }

        public static void AskEstimatedVehicleValue()
        {
            Console.Write("What is the estimated value of your vehicle: ");
        }

        public static void AskVehicleImported()
        {
            Console.Write("Has the vehicle been imported: Enter (Yes/No):");
        }

        public static void AskDatePurchasedVehicle()
        {
            Console.Write($"Whe did you purchase the vehicle: enter the date in one of the following formats (dd MMMM yyyy, dd/MM/yyyy, MM/dd/yyyy, yyyy-MM-dd, yyyy-dd-mm, yyyyddmm, yyyymmdd): ");
        }

        public static void AskForNumberOfSeats()
        {
            Console.Write("How many seats does your vehicle have: ");
        }

        #endregion

        #region Cover Messages 

        public static void AskIfProposerRegisteredKeeper()
        {
            Console.Write("Are you the registered keeper of the vehicle: ");
        }

        public static void AskWhoIsLegalOwner()
        {
            Console.Write("Who is the legal owner of the vehicle? please choose from the option displayed:");
        }

        public static void AskWhatCoverTheyWant()
        {
            Console.Write("Choose the type of cover you are after. Comprehensive, Third Party Fire and Theft, Third Party Only: ");
        }

        public static void AskPolicyStartDate()
        {
            Console.Write("What date would you like the cover to start: ");
        }

        public static void AskHowManyNCD()
        {
            Console.Write("How many years no claims bonus do you have: ");
        }

        public static void AskProtectNCB()
        {
            Console.Write("Would you like to protect your No Claims Bonus: ");
        }

        public static void AskVehicleTransmissionType()
        {
            Console.Write("What vehicle transmission type is your vehicle? (Manual or Automatic): ");
        }

        #endregion
    }
}
