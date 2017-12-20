using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class UserInterface
    {
        Adopter adopter = new Adopter();
        Employee employee = new Employee();

        public void InitialPrompt()
        {
            Console.WriteLine("Welcome to The Humane Society! \nChoose your path:\n [1] Employee\n [2] Adopter");
            string option = Console.ReadLine();
            InitialPromptOptions(option);
        }

        public void InitialPromptOptions(string option)
        {
            switch(option)
            {
                case "1":
                    employee.EmployeeInitialPrompt();
                    break;
                case "2":
                    adopter.AdopterInitialPrompt();
                    break;
                default:
                    Console.WriteLine("Please enter [1] for Employee or [2] for Adopter\n Press any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    InitialPrompt();
                    break;
            }
        }
    }
}
