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

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;";
                conn.Open();
                //humane.employee.Write(conn);
            }

            HumaneSociety humane = new HumaneSociety();
            
            humane.StartProgram();

            //THE OTHER OTHER GOD CODE - ADD
            //DataContext theHumaneSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
            //Test objTestAnimal = new Test();
            //objTestAnimal.Animal_Name = "Velguarder";
            //objTestAnimal.Color = "Purple";
            //objTestAnimal.Personality = "Vicious";
            //theHumaneSociety.GetTable<Test>().InsertOnSubmit(objTestAnimal);
            //theHumaneSociety.SubmitChanges();
            //Console.WriteLine("Adding in Velguarder!");
            //Console.ReadKey();

            //THIS IS THE OTHER GOD CODE - UPDATE
            //DataContext theHumanSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
            //var query =
            //    (from d in theHumanSociety.GetTable<Test_Animal>()
            //     where d.Animal_Name == "Bud"
            //     select d).First();

            //query.Animal_Name = "Not Bud";
            //Console.WriteLine(query.Animal_Name);
            //Console.ReadLine();


            //THIS IS THE GOD CODE - READ
            //DataContext theHumanSociety = new DataContext("Data Source=localhost;" + "Initial Catalog=TheHumaneSociety;" + "Integrated Security=SSPI;");
            //var query =
            //    from d in theHumanSociety.GetTable<Test_Animal>()
            //    where d.Animal_Name == "Bud"
            //    select d;
            //foreach(var d in query)
            //{
            //    Console.WriteLine(d.Color);
            //}
            //Console.ReadLine();


            //The Semi God Code, to change foreign id keys
            //using (DataContext db = new DataContext())
            //{
            //    Child c = new Child();
            //    c.ForeignKeyID = SomeID;
            //    db.InsertOnSubmit(c);
            //    db.SubmitChanges();
            //}
        }
    }
}
