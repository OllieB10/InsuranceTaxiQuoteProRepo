﻿using System.Text.RegularExpressions;
using DataAccess.Enums;

namespace TaxiQuoteEngineUI.Utility
{
    public static class PersonInputDetails
    {
        #region Gender Logic

        /// <summary>
        ///  Check if we have the gender the user has enterd.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static bool CheckValidGender(Gender gender)
        {
            Gender[] allowedGenders = { Gender.Male, Gender.Female, Gender.Other };

            return allowedGenders.Contains(gender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isGenderValid"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static Gender GetValidGender(string input)
        {
            input = ValidateUserInput.GetValidUserInput(input);

            // variable to store the users gender.
            Gender gender;

            // While we cannot parse or have the releavant gender the user wants then we keep them trpped until we have it.
            while (!Enum.TryParse(input, true, out gender) || !CheckValidGender(gender))
            {
                // New Line
                Console.WriteLine();
                //Inform user
                Console.WriteLine("The gender you entered is invalid, it cannot contain any special characters and must be either Male, Female or Other. " +
                                                 "Please enter your gender again or type 'exit' to quit.");

                // Store the users new response.
                input = Console.ReadLine() ?? string.Empty;

                //Check the desire to exit the application.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            // We must have a valid gender to get to here.
            return gender;
        }

        #endregion

        #region Relationship Status

        private static bool CheckValidRelationshipStatus(RelationshipStatus status)
        {
            RelationshipStatus[] allowedStatuses = { RelationshipStatus.Married, RelationshipStatus.Single, RelationshipStatus.Separated, RelationshipStatus.Widowed, RelationshipStatus.Divorced, RelationshipStatus.LivingWithPartner };

            return allowedStatuses.Contains(status);
        }

        public static RelationshipStatus GetValidRelationshipStatus(string input)
        {
            input = ValidateUserInput.FormatInputString(input);

            RelationshipStatus status;

            while (!Enum.TryParse(input, true, out status) || !CheckValidRelationshipStatus(status))
            {
                // New Line
                Console.WriteLine();

                // Inform user
                Console.WriteLine("The relationship status you entered is invalid, it cannot contain any special characters and must be either Married, Single Separated, Widowed, Divorced or Living with Partner");

                // New Line
                Console.WriteLine();

                // Ask user to enter their first name again.
                Console.WriteLine("Please enter your relationship status again (or type 'exit' to quit):  ");
                input = Console.ReadLine() ?? string.Empty;

                // Check the desire to exit the application.
                ExitApplication.CheckAndExitIfRequested(input);
            }

            return status;
        }

        #endregion

        #region Email Address Logic

        /// <summary>
        /// Check that the email address is valid using Regex.
        /// </summary>
        public static bool CheckValidEmailAddress(string email)
        {
            //regex patterns are used to determine e.g whether it is valid.
            string pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

            //Check if the email is valid or not.
            bool isMatch = Regex.IsMatch(email, pattern);

            return isMatch;
        }

        /// <summary>
        /// Return a valid email address.
        /// </summary>
        /// <param name="isEmailValid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string GetValidEmailAddress(string email)
        {
            email = email.Trim();

            string pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

            if (!CheckValidEmailAddress(email))
            {
                //The email address is not valid, Keep them in here until they provide a legit email.
                while (!Regex.IsMatch(email, pattern))
                {
                    //Inform user.
                    Console.WriteLine("The email address you entered is invalid.");

                    // New Line
                    Console.WriteLine();

                    //Ask user to enter their first name again.
                    Console.WriteLine("Please enter your email address again or type 'exit' to quit.  ");

                    email = Console.ReadLine() ?? string.Empty;

                    //Give the user a way to exit the application if desired.
                    ExitApplication.CheckAndExitIfRequested(email);
                }

                //return the new valid email address.
                return email;
            }

            //Return the original email as it is valid.
            return email;
        }

        #endregion
    }
}
