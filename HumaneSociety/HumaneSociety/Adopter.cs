using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Adopter
    {
        UserInterface ui = new UserInterface();

        public void AdopterNewUserPrompt()
        {
            Console.WriteLine("Are you a new user?"); // y/n?
            string option = Console.ReadLine();
            AdopterNewUserOption(option);
        }

        public void AdopterNewUserOption(string option)
        {
            switch(option)
            {
                case "y":
                    AdopterNewProfile();
                    break;
                case "n":
                    AdopterMainMenu();
                    break;
                default:
                    ui.IncorrectInput();
                    break;
            }
        }

        public void AdopterNewProfile()
        {
            //These push to the SQL Database for user
            string userProfile;
            string userName;
            string userAge;
            string userGender;
            string userEmail;
            string userPhone;

            Console.WriteLine("Let's set up your new profile!");
            userName = ui.GetAnimalName();
            userAge = ui.GetAge();
            userGender = ui.GetGender();
            userEmail = ui.GetEmail();
            userPhone = ui.GetPhone();
            userProfile = ui.GetProfile();
            //Confirmation method for inputted data "is this information correct?"
        }

        public void AdopterMainMenu() //adopter search menu
        {
            Console.WriteLine("");
        }
    }
}
