using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    interface ISqlConnector
    {
        void OpenSqlConnection();
        void CloseSqlConnection(SqlConnection conn);
        void Read();
        void Write();
        
    }
}
