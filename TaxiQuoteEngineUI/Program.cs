// See https://aka.ms/new-console-template for more information

using DataAccess.Enums;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.RatingTable;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Interfaces;
using ServiceLayer.Utility;
using TaxiQuoteEngineUI.Utility;

namespace TaxiQuoteEngineUI
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                          Host.CreateDefaultBuilder(args)
                              .ConfigureServices((_, services) =>
                          {
                              services.AddSingleton<IVehicleValueTable, VehicleValueTable>();
                              services.AddSingleton<IVehicleUseTable, VehicleUseTable>();
                              services.AddSingleton<IVehicleTransmissionTable, VehicleTransmissionTable>();
                              services.AddSingleton<IVehicleAgeTable, VehicleAgeTable>();
                              services.AddSingleton<ISeatsTable, SeatsTable>();
                              services.AddSingleton<IMotorConvictionsTable, MotorConvictionsTable>();
                              services.AddSingleton<IMotorConvictionsTable, MotorConvictionsTable>();
                              services.AddSingleton<IMinimumPremiumTable, MinimumPremiumTable>();
                              services.AddSingleton<IDriverAgeTable, DriverAgeTable>();
                              services.AddSingleton<ICoverTypeTable, CoverTypeTable>();
                              services.AddSingleton<IClaimsTable, ClaimsTable>();
                              services.AddSingleton<IBaseRateTable, BaseRateTable>();
                              services.AddSingleton<Policy, Policy>();
                              services.AddSingleton<Proposer, Proposer>();
                              services.AddSingleton<Vehicle, Vehicle>();
                              services.AddSingleton<Driver, Driver>();
                              services.AddSingleton<Policy, Policy>();
                              services.AddTransient<ICalculation, Calculation>();
                              services.AddTransient<ICalculationService, CalculationService>();
                          });

        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using IServiceScope? scope = host.Services.CreateScope();

            IServiceProvider? services = scope.ServiceProvider;
        
            Policy? policy = services.GetRequiredService<Policy>();
            Proposer? proposer = services.GetRequiredService<Proposer>();
            Vehicle? vehicle = services.GetRequiredService<Vehicle>();
            Driver? driver = services.GetRequiredService<Driver>();
            ICalculationService? calculation = services.GetRequiredService<ICalculationService>();

            #region Welcome User

            // Welcome the user to the application.
            ProposerMessages.WelcomeUser();

            #endregion

            // Blank line.
            Console.WriteLine();

            /*********************** Proposer Details Main Body Section Starts ********************************/

            #region Person Details

            #region First Name

            //Ask for the users first name.
            ProposerMessages.AskFirstName();
            string firstName = Console.ReadLine() ?? string.Empty;

            proposer.FirstName = ValidateUserInput.GetValidUserInput(firstName);

            #endregion

            // Store the valid last name.
            Console.WriteLine();

            #region Last Name

            //Ask for the users last name.
            ProposerMessages.AskLastName();
            string lastName = Console.ReadLine() ?? string.Empty;

            proposer.LastName = ValidateUserInput.GetValidUserInput(lastName);

            #endregion

            // Create blank line.
            Console.WriteLine();

            #region Date of Birth

            //Ask the user for their Date of Birth.
            ProposerMessages.AskDateOfBirth();
            string dateOfBirthAnswer = Console.ReadLine() ?? string.Empty;

            // Date of birth.
            proposer.DateOfBirth = DateFormats.GetValidDate(dateOfBirthAnswer);

            #endregion

            // Create blank line.
            Console.WriteLine();

            #region Gender

            // Ask the proposer for their gender.
            ProposerMessages.AskGender();
            string genderAnswer = Console.ReadLine() ?? string.Empty;

            // Get the valid gender.
            Gender gender = PersonInputDetails.GetValidGender(genderAnswer);

            #endregion

            Console.WriteLine();

            #region Email Address

            // Ask the proposer for their email address.
            ProposerMessages.AskEmailAddress();
            string email = Console.ReadLine() ?? string.Empty;

            proposer.EmailAddress = PersonInputDetails.GetValidEmailAddress(email);

            #endregion

            Console.WriteLine();

            #region Relationship Status

            // Ask proposer for their relationship status.
            ProposerMessages.AskRelationshipStatus();
            string relationshipStatusAnswer = Console.ReadLine() ?? string.Empty;

            // Store the relationship status.
            proposer.RelationshipStatus = PersonInputDetails.GetValidRelationshipStatus(relationshipStatusAnswer);

            #endregion

            #endregion

            Console.WriteLine();

            /*********************** Vehicle Main Body Section Starts ********************************/

            #region Vehicle Details           

            #region Year of Manufacture

            //Ask the proposer for the year of manufacture and Store the users answer.
            ProposerMessages.AskYearOfManufacture();
            string yearOfManufactureAnswer = Console.ReadLine() ?? string.Empty;

            vehicle.YearOfManufacture = DateFormats.GetYear(yearOfManufactureAnswer);

            #endregion

            Console.WriteLine();

            #region Vehicle Seats

            ProposerMessages.AskForNumberOfSeats();
            string numberOfSeatsAnswer = Console.ReadLine() ?? string.Empty;

            vehicle.NoOfSeats = VehicleInputDetails.GetNumberOfSeats(numberOfSeatsAnswer);

            #endregion

            Console.WriteLine();

            #region Vehicle Value

            ProposerMessages.AskEstimatedVehicleValue();
            string vehicleEstimatedValueAnswer = Console.ReadLine() ?? string.Empty;

            vehicle.EstimatedValue = VehicleInputDetails.GetEstimatedVehicleValue(vehicleEstimatedValueAnswer);

            if (vehicle.EstimatedValue > 70000.00M)
            {
                DeclineQuote.Decline("The vehicles estimated value is too high, we cannot provide you with a quote.");
            }
            else if (vehicle.EstimatedValue < 2000.00M)
            {
                DeclineQuote.Decline("The vehicles estimated value is too low, we cannot provide you with a quote.");
            }

            #endregion

            Console.WriteLine();

            #region Vehicle Transmissions

            ProposerMessages.AskVehicleTransmissionType(); // e.g Manual or Automatic
            string vehicleTransAnswer = Console.ReadLine() ?? string.Empty;

            VehicleTransmission vehicleTransmission = VehicleInputDetails.GetValidVehicleTransmission(vehicleTransAnswer);

            #endregion

            #endregion

            Console.WriteLine();

            /*********************** Vehicle Main Body Section Ends ********************************/


            /***********************Driver Main Body Section Starts********************************/

            #region Driver Details

            #region Previously Refused Cover

            ProposerMessages.AskPreviouslyRefusedCover();
            string refusedCoverAnswer = Console.ReadLine() ?? string.Empty;

            driver.InsurancePreviouslyRefused = YesNoInputHandler.ReturnTrueOrFalse(refusedCoverAnswer);

            Console.WriteLine();

            if (driver.InsurancePreviouslyRefused)
            {
                DeclineQuote.Decline("Sorry, we do not allow those who have previously been refused cover to get a quote.");
            }

            #endregion

            #region Previously Had Terms Applied.

            ProposerMessages.AskPreviouslyHadTermsApplied();
            string previousTermsApplied = Console.ReadLine() ?? string.Empty;

            driver.PreviouslyHadTermsApplied = YesNoInputHandler.ReturnTrueOrFalse(previousTermsApplied);

            Console.WriteLine();

            if (driver.PreviouslyHadTermsApplied)
            {
                DeclineQuote.Decline("Sorry, we do not allow those who have previously had their insurance terms applied to get a quote.");
            }

            #endregion

            #region Disqualified from Driving

            ProposerMessages.AskDisqualifiedFromDriving();
            string disqualifiedFromDriving = Console.ReadLine() ?? string.Empty;

            driver.DisqualifiedFromDriving = YesNoInputHandler.ReturnTrueOrFalse(disqualifiedFromDriving);

            Console.WriteLine();

            if (driver.DisqualifiedFromDriving)
            {
                DeclineQuote.Decline("Sorry, we do not allow those who have previously been disqualified from driving to get a quote.");
            }

            #endregion

            #region Vehicle Use

            // Ask for the vehicle use.
            ProposerMessages.AskVehicleUsage();  // Public Hire, Private Hire or Other.
            string vehicleUseAnswer = Console.ReadLine() ?? string.Empty;

            // Get the correct vehicle use.
            vehicle.VehicleUsage = VehicleInputDetails.GetVehicleUsage(vehicleUseAnswer);

            #endregion

            Console.WriteLine();

            #region Parking Overnight

            ProposerMessages.AskVehicleKeptAtHomeOverNight();
            string vehicleHomeNightAnswer = Console.ReadLine() ?? string.Empty;

            bool isAtHome = YesNoInputHandler.ReturnTrueOrFalse(vehicleHomeNightAnswer);

            // Store our parking location overnight value.
            vehicle.ParkingLocations = VehicleParkingLocationHandler.GetParkingLocationOvernight(isAtHome);

            #endregion

            Console.WriteLine();

            #region Criminal Convictions

            ProposerMessages.AskAnyCriminalConvictions();
            string criminalConvictionsAnswer = Console.ReadLine() ?? string.Empty;

            if (YesNoInputHandler.ReturnTrueOrFalse(criminalConvictionsAnswer))
            {
                DeclineQuote.Decline("Sorry, We do not allow drivers who have criminal convictions on this scheme.");
            }

            #endregion

            Console.WriteLine();

            #region Motor Claims

            // Ask the user if they have had any Motor Claims.
            ProposerMessages.AskAnyMotorClaims();
            string incidentsAnswer = Console.ReadLine() ?? string.Empty;

            // Get a yes or No response which we convert to true or false.
            bool hasIncidents = YesNoInputHandler.ReturnTrueOrFalse(incidentsAnswer);

            Console.WriteLine();

            List<MotorClaim> motorClaims = new List<MotorClaim>();

            // Types include, Accident and Other.
            IncidentType incidentType;

            // We need to loop through each claim question if the user has had claims.
            while (hasIncidents)
            {
                // Ask for the incident type.
                ProposerMessages.AskIncidentType();
                string incidentAnswer = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();

                // Store the incident type as an enum value to be used later.
                incidentType = DriverInputDetails.GetValidIncidentType(incidentAnswer);

                // If we have an accident incident type.
                if (incidentType == IncidentType.Accident)
                {
                    // 1. At fault? (Yes/No).
                    ProposerMessages.AskAtFault();
                    string faultAnswer = Console.ReadLine() ?? string.Empty;

                    // Save the details for later use.
                    motorClaims.Add(new MotorClaim { AtFault = YesNoInputHandler.ReturnTrueOrFalse(faultAnswer), IncidentType = incidentType });
                }
                // If not AccidentType then save Other.
                else
                {
                    // 1. At fault? (Yes/No).
                    ProposerMessages.AskAtFault();
                    string faultAnswer = Console.ReadLine() ?? string.Empty;

                    // Save the details for later use.
                    motorClaims.Add(new MotorClaim { AtFault = YesNoInputHandler.ReturnTrueOrFalse(faultAnswer), IncidentType = incidentType });
                }

                Console.WriteLine();

                // Ask for anymore incidents.
                ProposerMessages.AskAnyMoreIncidents();
                string moreIncidentsAnswer = Console.ReadLine() ?? string.Empty;

                // Determine if we have more incidents to add.
                bool moreIncidents = YesNoInputHandler.ReturnTrueOrFalse(moreIncidentsAnswer);

                // Check for any more Claims.
                hasIncidents = IncidentInputHandler.CheckMoreIncidents(moreIncidents);

                Console.WriteLine();
            }

            #endregion

            #region Motoring Convictions

            // Ask how many motoring convictions.
            ProposerMessages.AskHowManyMotorConvictions();
            string numberOfMotConAnswer = Console.ReadLine() ?? string.Empty;

            // Validate the answer.
            int motorConvictions = ValidateUserInput.GetValidInteger(numberOfMotConAnswer);

            #endregion - Ready for testing.

            Console.WriteLine();

            #region Full Uk Licence

            // Ask the user if they have a full UK driving licence and get the answer.
            ProposerMessages.AskWhetherHaveFullUkLicence();
            string fullUkLicenceAnswer = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();

            // If the user does not have a full UK Licence type then we cannot provide a quote.
            if (!YesNoInputHandler.ReturnTrueOrFalse(fullUkLicenceAnswer))
            {
                // We only accept Full Uk Licence types.
                DeclineQuote.Decline("We only accept full UK driving licence types, we cannot provide you with a quote; Press enter to exit the quote journey.");
            }

            #endregion

            #endregion

            Console.WriteLine();

            /***********************Driver Main Body Section Ends********************************/


            /***********************Cover Details Main Body Section Starts********************************/

            #region Cover Type

            // Type of Cover looking for - including Comprehensive, Third Party Fire and Theft, Third Party Only
            ProposerMessages.AskWhatCoverTheyWant();
            string coverAnswer = Console.ReadLine() ?? string.Empty;

            CoverType cover = CoverInputDetails.GetCoverType(coverAnswer);

            #endregion

            Console.WriteLine();

            #region Policy Start Date

            // Dates the user wants the cover to start.
            ProposerMessages.AskPolicyStartDate();
            string chosenStartDateAnswer = Console.ReadLine() ?? string.Empty;

            DateTime chosenStartDate = DateFormats.GetValidDate(chosenStartDateAnswer);

            while (chosenStartDate.Date <= DateTime.Today)
            {
                ProposerMessages.MessageUser("You must choose a future date, earliest starting date is from tomorrow, please enter your start date again.");
                chosenStartDateAnswer = Console.ReadLine() ?? string.Empty;

                chosenStartDate = DateFormats.GetValidDate(chosenStartDateAnswer);
            }

            #endregion

            Console.WriteLine();

            #region NCD Years

            // Years NCD the user has.
            ProposerMessages.AskHowManyNCD();
            string ncdAnswer = Console.ReadLine() ?? string.Empty; 

            // Store the amount of No Claims Bonus the user has.
            NCB ncb = CoverInputDetails.GetNCDAmount(ncdAnswer);

            #endregion

            /***********************Cover Details Main Body Section Ends********************************/


            /***********************Calculate Rate Main Body Section Starts********************************/

            #region Calculate Premium

            #region Base Rate Calculation

            // Set the Premium to the base rate.
            policy.NetPremium = calculation.CalculateBaseRateService(ncb);

            #endregion

            #region Driver Age Calculation

            int yearAtInception = DateHelper.GetAgeDifference(proposer.DateOfBirth, chosenStartDate);

            // This needs to be placed in our factory to adhere to Dependency Inversion.
            DriverAges driverAge = DriverInputDetails.GetDriverAgeEnum(yearAtInception);

            // Multiply the rate from the age table to get the new Net premium total.
            policy.NetPremium = policy.NetPremium * calculation.CalculateDriversAgeService(ncb, driverAge);

            #endregion

            #region Vehicle Value Calculation

            // Factor the estimated vehicle value into the price.
            policy.NetPremium = policy.NetPremium * calculation.CalculateVehicleValueService(vehicle);

            #endregion

            #region Vehicle Use Calculation

            // Factor in the Vehicle Use Value to the Net premium.
            policy.NetPremium = policy.NetPremium * calculation.CalculateVehicleUseService(vehicle.VehicleUsage);

            #endregion

            #region Vehicle Seats Calculation

            policy.NetPremium = policy.NetPremium * calculation.CalculateVehicleSeatsRateService(vehicle);

            #endregion

            #region Vehicle Transmission Calculation

            policy.NetPremium = policy.NetPremium * calculation.CalculateVehicleTransmissionRateService(vehicleTransmission);

            #endregion

            #region Minimum Premium Calculation

            policy.NetPremium = MinimumPremiumChecker.CheckMinimumPremium(policy.NetPremium, calculation.CalculateMinimumPremiumService(ncb));

            #endregion

            #region Motor Claims Calculation

            policy.NetPremium = policy.NetPremium * calculation.CalculateClaimsRateService(motorClaims, ncb);

            #endregion

            #region Motor Convictions Calculation

            policy.NetPremium = policy.NetPremium * calculation.CalculateMotorConvictionsService(motorConvictions);

            policy.NetPremium = Math.Round(policy.NetPremium, 2);

            #endregion

            #endregion

            /*********************** Calculate Rate Main Body Section Ends ********************************/

            /*********************** Display Premium Price Main Body Section Starts ********************************/

            Console.WriteLine();

            ProposerMessages.MessageUser($"Personal Information");
            ProposerMessages.MessageUser($"Full Name: {proposer.FirstName} {proposer.LastName}");
            ProposerMessages.MessageUser($"Date of Birth: {proposer.DateOfBirth.ToString()}");
            ProposerMessages.MessageUser($"Gender: {gender.ToString()}");
            ProposerMessages.MessageUser($"Email Address: {proposer.EmailAddress}");
            string relationshipStatus = (proposer.RelationshipStatus == RelationshipStatus.LivingWithPartner) ? "Living With Partner" : proposer.RelationshipStatus.ToString();
            ProposerMessages.MessageUser($"Relationship Status: {relationshipStatus}");
            Console.WriteLine();
            ProposerMessages.MessageUser($"Vehicle Information");
            ProposerMessages.MessageUser($"Year of Manufacture: {vehicle.YearOfManufacture.ToString()}");
            ProposerMessages.MessageUser($"Vehicle Seats: {vehicle.NoOfSeats.ToString()}");
            ProposerMessages.MessageUser($"Vehicle Value: £{vehicle.EstimatedValue.ToString()}");
            ProposerMessages.MessageUser($"Vehicle Transmission: {vehicleTransmission.ToString()}");
            Console.WriteLine();
            ProposerMessages.MessageUser($"Driver Information");
            string vehicleUse = (vehicle.VehicleUsage == VehicleUse.PublicHire) ? "Public Hire" : (vehicle.VehicleUsage == VehicleUse.PrivateHire) ? "Private Hire" : "Other";
            ProposerMessages.MessageUser($"Vehicle Use: {vehicleUse}");
            ProposerMessages.MessageUser($"Parking Location Overnight: {vehicle.ParkingLocations.ToString()}");
            ProposerMessages.MessageUser($"Total Claims: {motorClaims.Count}");
            ProposerMessages.MessageUser($"Total Motor Convictions: {motorConvictions}");
            Console.WriteLine();
            ProposerMessages.MessageUser($"Cover Information");
            string coverAsString = (cover == CoverType.ThirdPartyFireAndTheft) ? "Third Party FireAnd Theft" : (cover == CoverType.ThirdPartyOnly) ? "Third Party Only" : cover.ToString(); ;
            ProposerMessages.MessageUser($"Cover Type: {coverAsString}");
            ProposerMessages.MessageUser($"Start Date: {chosenStartDate.ToString()}");
            ProposerMessages.MessageUser($"No Claims Bonus: {ncb}");
            Console.WriteLine();
            ProposerMessages.MessageUser($"Price");
            ProposerMessages.MessageUser($"Total Net Premium Excluding IPT £{policy.NetPremium}");

            ProposerMessages.MessageUser($"Please close the application");
            /*********************** Diplay Premium Price Main Body Section Ends ********************************/

            //Keep the console window open until purposefully closed.
            Console.ReadLine();
        }
    }
}

