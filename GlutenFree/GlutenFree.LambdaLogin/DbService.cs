using MySqlConnector;
using System;
using System.Threading.Tasks;

namespace GlutenFree.Login
{
    class DbService
    {
        static public String databaseName = "login";
        static public String tableName = "UserLogin";

        //That is, column number 0 of the UserLogin table and so on...
        static public int userId = 0;
        static public int userEmail = 1;
        static public int userPassword = 2;

        static public string DbConnectionString
        {
            get
            {
                try
                {
                    string host = Environment.GetEnvironmentVariable("HOST");
                    string name = Environment.GetEnvironmentVariable("NAME");
                    string passwd = Environment.GetEnvironmentVariable("PASSWD");
                    string port = Environment.GetEnvironmentVariable("PORT");

                    string connectionString = String.Format("Server={0};User ID={1};Password={2};Database={3}",
                                       host, name, passwd, databaseName);
                    Console.WriteLine("Connection string: " + connectionString);

                    return connectionString;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return "";
                }
            }
        }

        static public async Task<Boolean> UserAlreadyExists(string email, MySqlConnection dbConnection)
        {
            Console.WriteLine("Check if the user already exists for " + email);
            try
            {
                await using var cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM {0} WHERE em='{1}'",
                    tableName, email), dbConnection);
                await using var reader = await cmd.ExecuteReaderAsync();
                return (await reader.ReadAsync());
            }
            catch
            {
                Console.WriteLine("The user " + email + " does not exists.");
                return false;
            }
        }
    }
}
