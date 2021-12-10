using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SQLiteDataAccess
    {
        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("select * from Users", new DynamicParameters());
                return output.ToList();
            }
        }
        private static string LoadConnectionString(string id = "Defualt")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
