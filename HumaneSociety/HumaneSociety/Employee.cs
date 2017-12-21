using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            Console.WriteLine("[1] Add animal \n[2] Search animal \n[3] SSearch Adopter");
            string option = Console.ReadLine();
            EmployeeMenuOptions(option);
        }

        public void EmployeeMenuOptions(string option)
        {
            switch(option)
            {
                case "1":
                    AddAnimal();
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

        public void AddAnimal()
        {
              
            string animalName = ui.GetAnimalName();
            string species = ui.GetSpecies();
            string gender = ui.GetGender();
            string age = ui.GetAge();
            string size = ui.GetSize();
            string room = ui.GetRoom();
            string personalityColor = ui.GetPersonalityColor();

            DisplayInput(animalName, age, species, gender, size, room, personalityColor);
        }

        //for employee, AddAnimal Method
        public void DisplayInput(string animalName, string age, string species, string gender, string size, string room, string personalityColor)
        {
            bool write = false;

            Console.Clear();
            Console.WriteLine("Name: " + animalName + "\nAge: " + age + "\nGender: " + gender + "\nSize: " + size + "\nPersonality Color: " + personalityColor);
            write = ConfirmInput();
            if (write == true)
            {
                //pass all answer variables into write method for SQL databsase
                EmployeeMainMenu();
            }
            EmployeeMainMenu();
        }

        public bool ConfirmInput() //add to Employee AddAnimal method
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
                    //userInput =
                    //ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "5":
                    referenceColumn = "Food";
                    //userInput =
                    //ConductSearch(referenceTable, referenceColumn, userInput);
                    break;
                case "6":
                    ChooseAnimalTypeToSearch();
                    break;                    
                default:
                    ui.IncorrectInput();
                    break;
                    //SELECT * FROM referenceTable WHERE referenceColumn=userInput

            }
        }
        private void ConductSearch(string referenceTable, string referenceColumn, string userInput)
        {

        }

        //void ISqlConnector.OpenSqlConnection()
        //{
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = "Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;";
        //        conn.Open();
        //    }
        //}

        //void ISqlConnector.CloseSqlConnection(SqlConnection conn)
        //{
        //    conn.Close();
        //}

        public void Read(SqlConnection conn, string command)
        {
            SqlDataReader myReader = null;
            //SqlCommand myCommand = new SqlCommand(commandString, conn);
            SqlCommand myCommand = new SqlCommand(command, conn);        
            myReader = myCommand.ExecuteReader();
            while(myReader.Read())
            { 
                 Console.WriteLine(myReader["Size"].ToString());
            }
        }

        public void Write(SqlConnection conn, string command)
        {
            //SqlCommand myCommand = new SqlCommand(commandString, conn);
            SqlCommand myCommand = new SqlCommand(command, conn);
            myCommand.ExecuteNonQuery();

        }
    }
}
