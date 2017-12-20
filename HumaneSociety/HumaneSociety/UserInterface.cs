using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class UserInterface
    {
        public void IncorrectInput()
        {
            Console.Clear();
            Console.WriteLine("Incorrect input. Please enter the available options. Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
