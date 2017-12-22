using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Linq;

namespace HumaneSociety
{
    class Employee
    {
        UserInterface ui = new UserInterface();
        private void CloseSqlConnection()
        {
            
        }
        public void EmployeeMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome Employee of The Humane Society.\n\nWhat is on the agenda today?");
            Console.WriteLine("[1] Add animal \n[2] Search animal \n[3] Search Adopter");
            string option = Console.ReadLine();
            EmployeeMenuOptions(option);
        }

        public void EmployeeMenuOptions(string option)
        {
            switch(option)
            {
                case "1":
                    string searchType = ConfirmAnimalType();
                    Console.WriteLine("Searching for a " + searchType);
                    AddAnimal(searchType);
                    break;
                case "2":
                    ChooseAnimalTypeToSearch();
                    break;
                case "3":

                    break;
                default:
                    ui.IncorrectInput();
                    EmployeeMainMenu();
                    break;
            }
        }

        public string ConfirmAnimalType()
        {
            Console.Clear();
            Console.WriteLine("What kind of pet do you want to search for?");
            Console.WriteLine("[1] Dog \n[2] Cat \n[3] Small Animal");
            string option = Console.ReadLine();
            string addType = GetDatabaseType(option);
            return addType;
        }

        public string GetDatabaseType(string option)
        {
            switch(option)
            {
                case "1":
                    option = "Animals.Dogs";
                    return option;
                case "2":
                    option = "Animals.Cats";
                    return option;
                case "3":
                    option = "Animals.Small_Animals";
                    return option;
                default:
                    ui.IncorrectInput();
                    ConfirmAnimalType();
                    return option = "";
            }
        }

        public void AddAnimal(string searchType)
        {              
            string animalName = ui.GetAnimalName();
            string gender = ui.GetGender();
            string age = ui.GetAge();
            string shots = ui.GetShots();
            string size = ui.GetSize();
            string food = ui.GetFood();
            string room = ui.GetRoom();
            string adopted = ui.GetAdopted();
            string personalityColor = ui.GetPersonalityColor();

            DisplayInput(animalName, age, gender, size, room, personalityColor, shots, food, adopted);
            
        }

        public void DisplayInput(string animalName, string age, string gender, string size, string room, string personalityColor, string shots, string food, string adopted)
        {
            bool confirmWrite = false;

            Console.Clear();
            AnimalDisplayInput(animalName, age, gender, size, room, personalityColor, shots, food, adopted);
            Console.WriteLine("Name: " + animalName + "\nAge: " + age + "\nGender: " + gender + "\nShots: " + shots + "\nSize: " + size + "\nFood: " + food + "\nPersonality Color: " + personalityColor);
            confirmWrite = ConfirmInput();
            if (confirmWrite == true)
            {
                //Write(animalName, gender, age, size, adopted, room, food, personalityColor, shots); //write to SQL database
                Console.WriteLine("Pet has been successfully added to the database! (Press any key to continue)");
                Console.ReadKey();
                EmployeeMainMenu();
            }
            EmployeeMainMenu();
        }

        public void AnimalDisplayInput(string animalName, string age, string gender, string size, string room, string personalityColor, string shots, string food, string adopted)
        {
            gender = ui.ConvertGenderOption(gender);
            size = ui.ConvertSizeOption(size);
            Console.Clear();
            Console.WriteLine("Name: " + animalName + "\nAge: " + age + "\nGender: " + gender + "\nShots: " + shots + "\nSize: " + size + "\nFood: " + food + "\nPersonality Color: " + personalityColor);
        }

        public bool ConfirmInput()
        {
            bool write = false;

            Console.WriteLine("\nIs this information correct? [y/n]");
            string answer = Console.ReadLine();
            if (answer != "n")
            {
                write = true;
                return write;
            }
            return false;
        }

        public void ChooseAnimalTypeToSearch()
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2", "3", "4" };
            Console.WriteLine("What type of animal are you searching for?");
            Console.WriteLine("[1] Dog \n[2] Cat \n[3] Small Animal \n[4] Return");
            string option = Console.ReadLine();
            isInputValid = ui.ValidateUserInput(options, option);
            if(isInputValid)
            {
                AnimalTypeSearchOption(option);
            }
            else
            {
                ui.IncorrectInput();
                ChooseAnimalTypeToSearch();
            }
        }

        public void AnimalTypeSearchOption(string option)
        {
            string referenceTable;
            switch(option)
            {
                case "1":
                    referenceTable = "Animals.Dogs";
                    ChooseAnimalTraitToSearch(referenceTable);
                    break;
                case "2":
                    referenceTable = "Animals.Cats";
                    ChooseAnimalTraitToSearch(referenceTable);
                    break;
                case "3":
                    referenceTable = "Animals.Small_Animals";
                    ChooseAnimalTraitToSearch(referenceTable);
                    break;
                case "4":
                    EmployeeMainMenu();
                    break;
                default:
                    ui.IncorrectInput();
                    ChooseAnimalTypeToSearch();
                    break;
            }
        }
        private void ChooseAnimalTraitToSearch(string referenceTable)
        {
            bool isInputValid = false;
            List<string> options = new List<string>() { "1", "2", "3", "4", "5", "6" };
            Console.WriteLine("What trait would you like to search by?");
            Console.WriteLine("[1] Name \n[2] Size \n[3] Room \n[4] Shots \n[5] Food \n[6] Return");
            string option = Console.ReadLine();
            isInputValid = ui.ValidateUserInput(options, option);
            if (isInputValid)
            {
                AnimalTraitSearchOption(option, referenceTable);
            }
            else
            {
                ui.IncorrectInput();
                ChooseAnimalTraitToSearch(referenceTable);
            }
        }
        public void AnimalTraitSearchOption(string option, string referenceTable)
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
                    referenceColumn = "Room";
                    userInput = ui.GetRoom();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "4":
                    referenceColumn = "Shots";
                    userInput = ui.GetSearchShots();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "5":
                    referenceColumn = "Food";
                    userInput = ui.GetFood();
                    ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "6":
                    ChooseAnimalTypeToSearch();
                    break;                    
                default:
                    ui.IncorrectInput();
                    ChooseAnimalTraitToSearch(referenceTable);
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
                if (searchTrait == null)
                {
                    searchTrait = ResolveSearchTrait(d, referenceColumn);
                }
                if(searchTrait.ToString() == userInput)
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
                Console.WriteLine("["+ optionsCounter.ToString() + "] " + searchResults[i].Animal_Name + "Gender: " + searchResults[i].Gender.Gender1 + "\nAge: " + searchResults[i].Age + "\nSize: " + searchResults[i].Size.Size1 + "\nAdopted Status: " + searchResults[i].Adopted_Status.Adopted_Status1 + "\nRoom: " + searchResults[i].Room.Room_ID + "\nFood type: " + searchResults[i].Food.Food_Type + "\nPersonality Color: " + searchResults[i].Personality.Color + "\nShot Status: " + searchResults[i].Shot.Shot_Status);
            }
            for (int j = 1; j <= searchResults.Count; j++)
            {
                options.Add(j.ToString());
            }
            userInput = ui.GetUserInput(options);
        }

        //public void Write(SqlConnection conn, string animalName, string gender, string age, string size, string adopted, string room, string food, string personalityColor)
        //{
        //    DataContext theHumaneSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
        //    Test objWrite = new Test();
        //    objWrite.Animal_Name = animalName;
        //    objWrite.Gender = gender;
        //    objWrite.Age = age;
        //    objWrite.Size = size;
        //    objWrite.Adopted = adopted;
        //    objWrite.Room = room;
        //    objWrite.Food = food;
        //    objWrite.Personality_Color = personalityColor;
        //    theHumaneSociety.GetTable<Animals.Dog>().InsertOnSubmit(objWrite);
        //    theHumaneSociety.SubmitChanges();
        //    Console.WriteLine("Adding Pet");
        //    Console.ReadKey();

        //}
        //public void Update()
        //{
        //    DataContext theHumanSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
        //    var query =
        //        (from d in theHumanSociety.GetTable<Test_Animal>()
        //         where d.Animal_Name == "Bud"
        //         select d).First();
        //public void Write(string animalName, string gender, string age, string size, string adopted, string room, string food, string personalityColor, string shots)
        //{
        //    DataContext theHumaneSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
        //    Dog objWrite = new Dog();          
        //    objWrite.Animal_Name = animalName;         
        //    objWrite.Gender_ID = Convert.ToInt32(gender);
        //    objWrite.Age = age;
        //    objWrite.Size_ID = Convert.ToInt32(size);
        //    objWrite.Adopted_ID = Convert.ToInt32(adopted);
        //    objWrite.Room_ID = Convert.ToInt32(room);
        //    objWrite.Food_ID = Convert.ToInt32(food);
        //    objWrite.Personality_Color_ID = Convert.ToInt32(personalityColor);
        //    objWrite.Shot_ID = Convert.ToInt32(shots);
        //    theHumaneSociety.GetTable<Dog>().InsertOnSubmit(objWrite);
        //    theHumaneSociety.SubmitChanges();
        //    Console.WriteLine("Adding Pet");
        //    Console.ReadKey();

        //    query.Animal_Name = "Not Bud";
        //    Console.WriteLine(query.Animal_Name);
        //    Console.ReadLine();
        //}
    }
}
