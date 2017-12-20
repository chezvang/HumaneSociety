using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Employee
    {
        UserInterface ui = new UserInterface();

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
                    SearchAnimal();
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

        }

        public void SearchAnimal()
        {
            Console.WriteLine("How would you like to search for the animal?");
            Console.WriteLine("[1] Name \n[2] Type \n[3] Room \n[4] Return");
            string option = Console.ReadLine();
            SearchOption(option);
        }

        public void SearchOption(string option)
        {
            switch(option)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":
                    EmployeeMainMenu();
                    break;
                default:

                    break;

            }
        }
    }
}
