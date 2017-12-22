using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace HumaneSociety
{
    class Adopter
    {
        UserInterface ui = new UserInterface();

        public void AdopterNewUserPrompt()
        {
            Console.Clear();
            Console.WriteLine("Are you a new user? Enter: [y/n]");
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
                    AdopterNewUserPrompt();
                    break;
            }
        }

        public void AdopterNewProfile()
        {
            //These push to the SQL Database for user

            Console.Clear();
            Console.WriteLine("Welcome new user. Let's set up your new profile!");
            string userName = ui.GetAnimalName();
            string userAge = ui.GetAge();
            string userGender = ui.GetGender();
            string userEmail = ui.GetEmail();
            string userPhone = ui.GetPhone();
            string userProfile = ui.GetProfile();
            //Confirmation method for inputted data "is this information correct?"
            //ui.DisplayInput(); //move DisplayInput into the UserInterfaces class
            DisplayInput(userProfile, userName, userAge, userGender, userEmail, userProfile);
        }

        public void DisplayInput(string userProfile, string userName, string userAge, string userGender, string userEmail, string userPhone)
        {
            bool write = false;

            Console.Clear();
            Console.WriteLine("Name: " + userName + "\nAge: " + userAge + "\nGender: " + userGender + "\nEmail: " + userEmail + "\nPhone: " + userPhone);
            Console.WriteLine("Profile:\n" + userProfile);
            Console.WriteLine("\nIs this information correct? (WARNING: If 'no', your information will be wiped and you will be brought back to the previous menu.");
            write = ConfirmInput();
            if(write == true)
            {
                
                AdopterMainMenu();
            }
                AdopterNewUserPrompt();
        }

        public bool ConfirmInput() //add to Employee AddAnimal method
        {
            bool write = false;

            Console.WriteLine("\nIs this information correct? [y/n]");
            string answer = Console.ReadLine();
            if(answer != "n")
            {
                write = true;
                return write;
            }
            return false;
        }

        public void AnimalShots()
        {
            Console.WriteLine("");
        }

        public void AdopterMainMenu() //adopter search menu
        {
            Console.Clear();
            Console.WriteLine("Welcome Adopter, what would you like to do today?");
            Console.WriteLine("[1] Search Pet \n[2] Return");
            string option = Console.ReadLine();
            AdopterMainMenuOption(option);
        }

        public void AdopterMainMenuOption(string option)
        {
            switch(option)
            {
                case "1":
                    AdopterTypeToSearch();
                    break;
                case "2":
                    AdopterNewUserPrompt();
                    break;
                default:
                    ui.IncorrectInput();
                    AdopterMainMenu();
                    break;
            }
        }

        public void AdopterTypeToSearch()
        {
            Console.Clear();
            Console.WriteLine("Adopter, searching for a pet. How would you like to search?");
            Console.WriteLine("[1] By Dog \n[2] By Cat \n[3] By Small Animal \n[4] Return");
            string option = Console.ReadLine();
            AdopterTypeSearchOption(option);
        }

        public void AdopterTypeSearchOption(string option)
        {
            string referenceTable;
            switch (option)
            {
                case "1":
                    referenceTable = "Animals.Dogs";
                    AdopterSearchByTraits(referenceTable);
                    break;
                case "2":
                    referenceTable = "Animals.Cats";
                    AdopterSearchByTraits(referenceTable);
                    break;
                case "3":
                    referenceTable = "Animals.Small_Animals";
                    AdopterSearchByTraits(referenceTable);
                    break;
                case "4":
                    AdopterMainMenu();
                    break;
                default:
                    ui.IncorrectInput();
                    AdopterTypeToSearch();
                    break;
            }
        }

        public void AdopterSearchByTraits(string referenceTable)
        {
            Console.Clear();
            Console.WriteLine("What trait would you like to search by?");
            Console.WriteLine("[1] Name \n[2] Size \n[3] Room \n[4] Shots \n[5] Food \n[6] Return");
            string option = Console.ReadLine();
            AdopterSearchByTraitsOptions(option, referenceTable);
        }

        public void AdopterSearchByTraitsOptions(string option, string referenceTable)
        {
            string referenceColumn;
            string userInput;
            switch (option)
                //use LINQ for search output
            {
                case "1":
                    referenceColumn = "Name";
                    userInput = ui.GetAnimalName();
                    //pass referenceColumn to SQL read
                    break;
                case "2":
                    referenceColumn = "Size";
                    userInput = ui.GetSize();
                    //pass referenceColumn to SQL read
                    break;
                case "3":
                    referenceColumn = "Room";
                    userInput = ui.GetRoom();
                    //pass referenceColumn to SQL read
                    break;
                case "4":
                    referenceColumn = "Shots";
                    userInput = ui.GetShots();
                    //pass referenceColumn to SQL read
                    break;
                case "5":
                    referenceColumn = "Food";
                    userInput = ui.GetFood();
                    //pass referenceColumn to SQL read
                    break;
                case "6":
                    AdopterTypeToSearch();
                    break;
                default:
                    ui.IncorrectInput();
                    AdopterSearchByTraits(referenceTable);
                    break;
            }
        }
        
        public void AskAdopt()
        {
            bool adopt = false;
            Console.WriteLine("Do you want to adopt this pet?");
            string option = Console.ReadLine();
            adopt = ui.ConfirmInput();
            if (adopt == false)
            {
                Console.WriteLine("You have choosen not to give this pet a home :( \nReturning to previous menu. (Press any key to continue)");
                Console.ReadKey();
                //return to previous menu, where am i coming from?
            }
            AdopterPayment();
        }

        public void AdopterPayment()
        {
            bool confirm = false;
            int price = PetCostGenerator();
            Console.WriteLine("This pet costs: $" + price + "\nDo you wish to purchase this pet?");
        }

        private int PetCostGenerator()
        {
            Random random = new Random();
            int price = random.Next(99, 251);
            return price;
        }

        public void Write(string userName, string userAge, string userGender, string userEmail, string userPhone, string userProfile)
        {
            DataContext theHumaneSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
            Customer objWrite = new Customer(); //change 'Test' to User table name
            objWrite.Adopter_Name = userName; //change to match table column
            objWrite.Age = userAge; //change to match table column
            objWrite.Gender_ID = Convert.ToInt32(userGender); //change to match table column
            objWrite.Email = userEmail; //change to match table column
            //objWrite.Phone_ID = userPhone; //change to match table column
            objWrite.Adopter_Profile = userProfile; //change to match table column
            theHumaneSociety.GetTable<Customer>().InsertOnSubmit(objWrite); //change to match table name
            theHumaneSociety.SubmitChanges();

            Console.WriteLine("Adding Profile");
            Console.ReadKey();
        }

        //public void Read(SqlConnection conn)
        //{
        //    SqlDataReader myReader = null;
        //    //SqlCommand myCommand = new SqlCommand(commandString, conn);
        //    SqlCommand myCommand = new SqlCommand("select * from Animals.Sizes", conn);
        //    myReader = myCommand.ExecuteReader();
        //    while (myReader.Read())
        //    {
        //        Console.WriteLine(myReader["Size"].ToString());
        //    }
        //}

        //public void Write(SqlConnection conn, string command)
        //{
        //    //SqlCommand myCommand = new SqlCommand(commandString, conn);
        //    SqlCommand myCommand = new SqlCommand(command, conn);
        //    myCommand.ExecuteNonQuery();

        //}
    }
}
