using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Linq;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {

            //DataContext db = new DataContext(@"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TheHumaneSociety.mdf");

            //db.GetTable

            HumaneSociety humane = new HumaneSociety();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;";
                conn.Open();
                //humane.employee.Write(conn);
            }
            humane.StartProgram();


            Console.ReadLine();
        }
    }
}
