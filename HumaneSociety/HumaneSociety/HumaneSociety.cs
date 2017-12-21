using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class HumaneSociety
    {
        UserInterface ui = new UserInterface();
        Adopter adopter = new Adopter();
       public Employee employee = new Employee();

        public void InitialPrompt()
        {
            Console.WriteLine("Welcome to The Humane Society! \nChoose your path: \n[1] Employee \n[2] Adopter");
            string option = Console.ReadLine();
            InitialPromptOptions(option);
        }

        public void InitialPromptOptions(string option)
        {
            switch (option)
            {
                case "1":
                    employee.EmployeeMainMenu();
                    break;
                case "2":
                    adopter.AdopterMainMenu();
                    break;
                default:
                    ui.IncorrectInput();
                    InitialPrompt();
                    break;
            }
        }

        public void StartProgram()
        {
            InitialPrompt();
        }
    }
}
