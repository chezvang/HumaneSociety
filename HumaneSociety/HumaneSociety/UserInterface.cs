using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class UserInterface
    {
        public string GetUserInput(List<string> options)
        {
            string userInput;
            Console.WriteLine(" ");
            userInput = Console.ReadLine();
            return userInput;
        }
        public string GetUserInput()
        {
            string userInput;
            Console.WriteLine(" ");
            userInput = Console.ReadLine();
            return userInput;
        }
        public bool ValidateUserInput(List<string> options, string userInput)
        {
            if (options.Contains(userInput))
            {
                return true;
            }
            return false;            
        }
        public bool ValidateUserInput(string userInput, int maxCharacterLength)
        {
            if(userInput.Length < maxCharacterLength )
            {
                return true;
            }
            return false;
        }
        public void IncorrectInput()
        {
            Console.Clear();
            Console.WriteLine("Incorrect input. Please enter the available options. Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public string GetAnimalName()
        {
            string userInput;
            int maxCharacterLength = 80;
            bool isInputValid = false;
            Console.Clear();
            Console.WriteLine("Please enter the name:");
            userInput = GetUserInput();
            isInputValid = ValidateUserInput(userInput, maxCharacterLength);
            if (!isInputValid)
            {
                IncorrectInput();
                GetAnimalName();
            }
            return userInput;
        }
        //public string GetSpecies() //remove when confirmed no longer needed
        //{
        //    string userInput;
        //    int maxCharacterLength = 80;
        //    bool isInputValid = false;
        //    Console.Clear();
        //    Console.WriteLine("Please enter the species:");
        //    userInput = GetUserInput();
        //    isInputValid = ValidateUserInput(userInput, maxCharacterLength);
        //    if (!isInputValid)
        //    {
        //        IncorrectInput();
        //        GetSpecies();
        //    }
        //    return userInput;
        //}
        public string GetGender()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Please enter the gender:");
            Console.WriteLine("[1] Male \n[2] Female");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetGender();
            }
            return userInput;
        }
        public string ConvertGenderOption(string userInput) //for display purposes only
        {
            string gender;
            if (userInput != "2")
            {
                gender = "Male";
            }
            gender = "Female";
            return gender;
        }
        public string GetAdopted()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Please enter the gender:");
            Console.WriteLine("[1] Adopted \n[2] Not Adopted");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetAdopted();
            }
            return userInput;
        }
        public string GetAge()
        {
            string userInput;
            int maxCharacterLength = 5;
            bool isInputValid = false;
            Console.Clear();
            Console.WriteLine("Please enter the age:");
            userInput = GetUserInput();
            isInputValid = ValidateUserInput(userInput, maxCharacterLength);
            if (!isInputValid)
            {
                IncorrectInput();
                GetAge();
            }
            return userInput;
        }
        public string GetSize()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2", "3", "4", "5" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Please enter the size:");
            Console.WriteLine("[1] Extra Small \n[2] Small \n[3] Medium \n[4] Large \n[5] Extra Large");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetSize();
            }
            return userInput;
        }
        public string ConvertSizeOption(string userInput) //for display purposes only
        {
            switch(userInput)
            {
                case "1":
                    userInput = "Extra Small";
                    return userInput;
                case "2":
                    userInput = "Small";
                    return userInput;
                case "3":
                    userInput = "Medium";
                    return userInput;
                case "4":
                    userInput = "Large";
                    return userInput;
                case "5":
                    userInput = "Extra Large";
                    return userInput;
                default:
                    return userInput = "";
            }
        }
        public string GetRoom()
        {
            string userInput;
            int maxCharacterLength = 4;
            bool isInputValid = false;
            Console.Clear();
            Console.WriteLine("Room numbers have a maximum of three digits");
            Console.WriteLine("Please enter the room number:");
            userInput = GetUserInput();
            isInputValid = ValidateUserInput(userInput, maxCharacterLength);
            if (!isInputValid)
            {
                IncorrectInput();
                GetRoom();
            }
            return userInput;
        }
        public string GetPersonalityColor()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2", "3", "4" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Please enter the personality color:");
            Console.WriteLine("[1] Purple \n[2] Orange \n[3] Green \n[4] Unrated/Pink");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetPersonalityColor();
            }
            return userInput;
        }
        public string GetEmail()
        {
            string userInput;
            int maxCharacterLength = 80;
            bool isInputValid = false;
            Console.Clear();
            Console.WriteLine("Please enter your email:");
            userInput = GetUserInput();
            isInputValid = ValidateUserInput(userInput, maxCharacterLength);
            if (!isInputValid)
            {
                IncorrectInput();
                GetEmail();
            }
            return userInput;
        }
        public string GetPhone()
        {
            string userInput;
            int maxCharacterLength = 11;
            bool isInputValid = false;
            Console.Clear();
            Console.WriteLine("Please enter your phone number:");
            userInput = GetUserInput();
            isInputValid = ValidateUserInput(userInput, maxCharacterLength);
            if (!isInputValid)
            {
                IncorrectInput();
                GetPhone();
            }
            return userInput;
        }
        public string GetProfile()
        {
            string userInput;
            int maxCharacterLength = 1000;
            bool isInputValid = false;
            Console.Clear();
            Console.WriteLine("This is your profile. Tell us something about your self!:");
            userInput = GetUserInput();
            isInputValid = ValidateUserInput(userInput, maxCharacterLength);
            if (!isInputValid)
            {
                IncorrectInput();
                GetProfile();
            }
            return userInput;
        }
        public string GetShots()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Does this animal have their shots?:");
            Console.WriteLine("[1] Has Shots \n[2] No Shots");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetSize();
            }
            return userInput;
        }
        public string GetSearchShots()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2", "3" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Does this animal have their shots?:");
            Console.WriteLine("[1] Has Shots \n[2] No Shots \n[3] All Shots");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetSize();
            }
            return userInput;
        }
        public string GetFood()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2", "3" };
            string userInput;
            Console.Clear();
            Console.WriteLine("Enter the type of food:");
            Console.WriteLine("[1] Dog Food \n[2] Cat Food \n[3] Small Animal Food");
            userInput = GetUserInput(options);
            isInputValid = ValidateUserInput(options, userInput);
            if (!isInputValid)
            {
                IncorrectInput();
                GetSize();
            }
            return userInput;
        }
        public bool ConfirmInput()
        {
            bool confirm = false;

            Console.WriteLine("\nIs this information correct? [y/n]");
            string answer = Console.ReadLine();
            if (answer != "n")
            {
                confirm = true;
                return confirm;
            }
            return false;
        }
        //public void DisplayInput()
        //{


        //}
    }
}
