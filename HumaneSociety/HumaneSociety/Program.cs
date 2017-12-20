using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            //link to SQL database
            //a way to import CSV file?

            HumaneSociety humane = new HumaneSociety();

            humane.StartProgram();

            Console.ReadLine();
        }
    }
}
