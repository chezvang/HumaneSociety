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
        public void GetAnimalName()
        {
            //validate for max character limit in DB
            Console.WriteLine("Please enter the name:");
        }
        public void GetSpecies()
        {
            //validate for max character limit in DB
            Console.WriteLine("Please enter the species:");
        }
        public void GetGender()
        {
            Console.WriteLine("[1] Male \n[2] Female");
            Console.WriteLine("Please enter the gender:");
        }
        public void GetAge()
        {
            //validate for max character limit in DB
            Console.WriteLine("Please enter the age:");
        }
        public void GetSize()
        {            
            Console.WriteLine("Please enter the size:");
            Console.WriteLine("[1] Extra Small \n[2] Small \n[3] Medium \n[4] Large \n[5] Extra Large");
        }
        public void GetRoom()
        {
            //needs a validater
            Console.WriteLine("Room numbers have a maximum of three digits");
            Console.WriteLine("Please enter the room number:");
        }
        public void GetPersonalityColor()
        {
            Console.WriteLine("Please enter the personality color:");
            Console.WriteLine("[1] Purple \n[2] Orange \n[3] Green \n[4] Unrated/Pink");
        }
    }
}
