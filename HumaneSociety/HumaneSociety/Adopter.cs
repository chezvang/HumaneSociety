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
        HumaneSocietyWallet wallet = new HumaneSocietyWallet();

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
            DisplayInput(userProfile, userName, userAge, userGender, userEmail, userProfile);
        }

        public void DisplayInput(string userProfile, string userName, string userAge, string userGender, string userEmail, string userPhone)
        {
            bool write = false;

            Console.Clear();
            AdopterDisplayInput(userName, userAge, userGender, userEmail, userPhone, userProfile);
            Console.WriteLine("\nIs this information correct? (WARNING: If 'no', your information will be wiped and you will be brought back to the previous menu.");
            write = ui.ConfirmInput();
            if(write == true)
            {
                //Write(userName, userAge, userGender, userEmail, userPhone, userProfile);
                //pass all answer variables into write method for SQL databsase
                AdopterMainMenu();
            }
                AdopterNewUserPrompt();
        }

        public void AdopterDisplayInput(string userName, string userAge, string userGender, string userEmail, string userPhone, string userProfile)
        {
            userGender = ui.ConvertGenderOption(userGender);
            Console.Clear();
            Console.WriteLine("Name: " + userName + "\nAge: " + userAge + "\nGender: " + userGender + "\nEmail: " + userEmail + "\nPhone: " + userPhone);
            Console.WriteLine("Profile:\n" + userProfile);
        }

        public void AnimalShots()
        {
            Console.WriteLine("");
        }

        public void AdopterMainMenu()
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
            Console.WriteLine("[1] Name \n[2] Size \n[3] Shots \n[4] Food \n[5] Return");
            string option = Console.ReadLine();
            AdopterSearchByTraitsOptions(option, referenceTable);
        }

        public void AdopterSearchByTraitsOptions(string option, string referenceTable)
        {
            string referenceColumn;
            string userInput;
            switch (option)
            {
                case "1":
                    referenceColumn = "Animal_Name";
                    userInput = ui.GetAnimalName();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "2":
                    referenceColumn = "Size";
                    userInput = ui.GetSize();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "3":
                    referenceColumn = "Shots";
                    userInput = ui.GetSearchShots();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "4":
                    referenceColumn = "Food";
                    userInput = ui.GetFood();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "5":
                    AdopterTypeToSearch();
                    break;
                default:
                    ui.IncorrectInput();
                    AdopterSearchByTraits(referenceTable);
                    break;
            }
        }
        private void ConductSearch(string referenceTable, string referenceColumn, string userInput)
        {
            object searchTrait = null;
            List<Dog> searchResults = new List<Dog>();
            DataContext theHumanSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
            var query =
                from d in theHumanSociety.GetTable<Dog>()
                select d;
            foreach (var d in query)
            {
                searchTrait = ResolveSearchTrait(d, referenceColumn);
                if (searchTrait.ToString() == userInput)
                {
                    searchResults.Add(d);
                }
            }
            MakeChoice(searchResults);
        }

        private object ResolveSearchTrait(Dog d, string referenceColumn)
        {
            object searchProperty = null;
            List<string> traits = new List<string>() { "Animal_Name", "Size", "Room", "Shots", "Food" };
            switch (referenceColumn)
            {
                case "Animal_Name":
                    searchProperty = d.Animal_Name;
                    return searchProperty;
                case "Size":
                    searchProperty = d.Size_ID;
                    return searchProperty;
                case "Room":
                    searchProperty = d.Room_ID;
                    return searchProperty;
                case "Shots":
                    searchProperty = d.Shot_ID;
                    return searchProperty;
                case "Food":
                    searchProperty = d.Food_ID;
                    return searchProperty;
            }
            return searchProperty;
        }
        private void MakeChoice(List<Dog> searchResults)
        {
            string userInput;
            int optionsCounter = 1;
            List<string> options = new List<string>();
            Console.WriteLine("Search Results:");
            for (int i = 0; i < searchResults.Count; i++)
            {
                Console.WriteLine("[" + optionsCounter.ToString() + "] " + searchResults[i].Animal_Name + "Gender: " + searchResults[i].Gender.Gender1 + "\nAge: " + searchResults[i].Age + "\nSize: " + searchResults[i].Size.Size1 + "\nAdopted Status: " + searchResults[i].Adopted_Status.Adopted_Status1 + "\nRoom: " + searchResults[i].Room.Room_ID + "\nFood type: " + searchResults[i].Food.Food_Type + "\nPersonality Color: " + searchResults[i].Personality.Color + "\nShot Status: " + searchResults[i].Shot.Shot_Status);
            }
            for (int j = 1; j <= searchResults.Count; j++)
            {
                options.Add(j.ToString());
            }
            userInput = ui.GetUserInput(options);
        }

        public void AskAdopt()
        {
            bool adopt = false;
            Console.WriteLine("Do you want to adopt this pet?");
            string option = Console.ReadLine();
            adopt = ui.ConfirmInput();
            if (adopt == false)
            {
                Console.WriteLine("You have chosen not to give this pet a home :( \nReturning to previous menu. (Press any key to continue)");
                Console.ReadKey();
                //return to previous menu, where am i coming from?
            }
            AdopterPayment();
        }

        public void AdopterPayment()
        {
            int price = PetCostGenerator();
            Console.WriteLine("This pet costs: $" + price + "\nDo you wish to purchase this pet? [y/n]");
            string answer = Console.ReadLine();
            if(answer == "y")
            {
                Console.WriteLine("Thank you for giving this lovely pet a new home! :) ");
                wallet.AddToWallet(price);
            }
            Console.WriteLine("You have chosen not to give this pet a home :( \nReturning to previous menu. (Press any key to continue)");
            Console.ReadKey();
            //return to previous menu, where am i coming from?
        }

        private int PetCostGenerator()
        {
            Random random = new Random();
            int price = random.Next(99, 251);
            return price;
        }

        //public void Write(string userName, string userAge, string userGender, string userEmail, string userPhone, string userProfile)
        //{
        //    DataContext theHumaneSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
        //    Test objWrite = new Test(); //change 'Test' to User table name
        //    objWrite.Name = userName; //change to match table column
        //    objWrite.Age = userAge; //change to match table column
        //    objWrite.Gender = userGender; //change to match table column
        //    objWrite.Email = userEmail; //change to match table column
        //    objWrite.Phone = userPhone; //change to match table column
        //    objWrite.Profile = userProfile; //change to match table column
        //    theHumaneSociety.GetTable<Animals.Dog>().InsertOnSubmit(objWrite); //change to match table name
        //    theHumaneSociety.SubmitChanges();

        //    Console.WriteLine("Adding Profile");
        //    Console.ReadKey();
        //}

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
