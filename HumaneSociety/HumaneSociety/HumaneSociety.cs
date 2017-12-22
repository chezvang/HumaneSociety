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
        public Adopter adopter = new Adopter();
        public Employee employee = new Employee();
        HumaneSocietyWallet wallet = new HumaneSocietyWallet();


        public void InitialPrompt()
        {
            wallet.AddToWallet(0);
            PendingAlert();
            Console.WriteLine("Welcome to The Humane Society! \nChoose your path: \n[1] Employee \n[2] Adopter \n[3] Exit Program\n");
            string option = Console.ReadLine();
            InitialPromptOptions(option);
        }

        public void PendingAlert()
        {
            bool alert = wallet.WalletAlert();
            if(alert == true)
            {
                Console.WriteLine("*There is a payment pending*\n");
            }
            else
            {
                Console.WriteLine("The Humane Society is currently broke.\n");
            }
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
