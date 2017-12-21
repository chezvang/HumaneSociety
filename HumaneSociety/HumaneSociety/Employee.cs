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
            string animalName;
            string species;
            string gender;
            string age;
            string size;
            string room;
            string personalityColor;   
              
            animalName = ui.GetAnimalName();
            species = ui.GetSpecies();
            gender = ui.GetGender();
            age = ui.GetAge();
            size = ui.GetSize();
            room = ui.GetRoom();
            personalityColor = ui.GetPersonalityColor();

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
                AnimalTypeSearchOption(option);
            }
            else
            {
                ui.IncorrectInput();
                ChooseAnimalTraitToSearch(referenceTable);
            }
        }
        public void AnimalTraitSearchOption(string option)
        {
            string referenceColumn;
            switch (option)
            {
                case "1":
                    referenceColumn = "Animals.Dogs";
                    ChooseAnimalTraitToSearch(referenceColumn);
                    break;
                case "2":
                    referenceColumn = "Animals.Cats";
                    ChooseAnimalTraitToSearch(referenceColumn);
                    break;
                case "3":
                    referenceColumn = "Animals.Small_Animals";
                    ChooseAnimalTraitToSearch(referenceColumn);
                    break;
                case "4":
                    EmployeeMainMenu();
                    break;
                default:

                    break;

            }
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

        public void Read(SqlConnection conn)
        {
            SqlDataReader myReader = null;
            //SqlCommand myCommand = new SqlCommand(commandString, conn);
            SqlCommand myCommand = new SqlCommand("select * from Animals.Sizes", conn);        
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
