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
        HumaneSocietyWallet wallet = new HumaneSocietyWallet();
        //write bool check for wallet, if there is money in wallet, display *adoption pending*
       public Employee employee = new Employee();

        public void InitialPrompt()
        {
            Console.WriteLine("Welcome to The Humane Society! \nChoose your path: \n[1] Employee \n[2] Adopter \n[3] Exit Program");
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
                    adopter.AdopterNewUserPrompt();
                    break;
                case "3":
                    Environment.Exit(0);
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
