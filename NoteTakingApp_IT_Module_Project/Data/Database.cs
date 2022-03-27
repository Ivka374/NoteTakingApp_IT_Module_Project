using MySql.Data.MySqlClient;

namespace NoteTakingApp_IT_Module_Project.Data
{
    class Database
    {
        //CRUDUsingDBCommands Method
        //NOTE: Add Connection String ASAP!!!
        //Connection String Template: "Server=localhost; Database=databaseName; username = someUsername; password = somePassword"
        private static string connectionString = "Server=localhost; Database=noteapp; username = root; password = G$sZen+TsQT%?Q8r";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
