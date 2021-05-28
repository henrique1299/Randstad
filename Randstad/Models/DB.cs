using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Randstad.Models
{
    public class DB
    {
        public DB() { }
        public SqlConnection connect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "farfetchdbserver.database.windows.net";
                builder.UserID = "henrique";
                builder.Password = "admin1299@";
                builder.InitialCatalog = "Farfetch_db";

                String conn = @"Server=(localdb)\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";
                SqlConnection connection = new SqlConnection(conn);
                return connection;

            }
            catch
            {
                return null;
            }
        }
    }
}
