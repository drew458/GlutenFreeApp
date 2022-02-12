using MySqlConnector;
using System;
using System.Threading.Tasks;

namespace GlutenFree.Login
{
    class LoginService : DbService
    {
        public static async Task<Codes> LoginAsync(string email, string password)
        {
            try 
            {
                var dbConnection = new MySqlConnection(DbConnectionString);
                await dbConnection.OpenAsync();

                Console.WriteLine("Login of " + email + "started");

                using (var dbQuery = new MySqlCommand(String.Format("SELECT * FROM {0} WHERE em='{1}'", tableName, email), dbConnection))
                using (var reader = await dbQuery.ExecuteReaderAsync())
                while (await reader.ReadAsync()) {
                    if (reader.GetString(userEmail).Equals(email) && reader.GetString(userPassword).Equals(EncryptionService.Encrypt(email, password)))
                        return Codes.GenericSuccess;
                    else
                        return Codes.LoginUserPasswordError;
                }

                return Codes.LoginUserNotExists;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problems occured with the login of " + email + " " + e.ToString() + "");
                return Codes.LoginGenericError;
            }
        }

        public static async Task<Codes> RegisterAsync(string email, string password)
        {
            try
            {
                Random randomGenerator = new Random();

                var dbConnection = new MySqlConnection(DbConnectionString);
                await dbConnection.OpenAsync();

                Console.WriteLine("Registration of " + email + " started...");

                if (await EmailAlreadyExists(email, dbConnection))
                    return Codes.RegistrationEmailExistsError;

                await using (var dbQuery = new MySqlCommand(String.Format("INSERT INTO {0}  VALUES (@id, @em, @pwd)", tableName), dbConnection))
                {
                    dbQuery.Parameters.AddWithValue("id", randomGenerator.Next(10, 9999999));
                    dbQuery.Parameters.AddWithValue("em", email);
                    dbQuery.Parameters.AddWithValue("pwd", EncryptionService.Encrypt(email, password));

                    await dbQuery.ExecuteNonQueryAsync();
                }

                return Codes.GenericSuccess;
            }
            catch
            {
                Console.WriteLine("Problems occured with the registration of " + email + "");
                return Codes.RegistrationError;
            }
        }

        private static async Task<bool> EmailAlreadyExists(string email, MySqlConnection dbConnection)
        {
            try
            {
                await using var dbQuery = new MySqlCommand(String.Format("SELECT * FROM {0} WHERE em='{1}'", tableName, email), dbConnection);
                await using var reader = await dbQuery.ExecuteReaderAsync();
                return await reader.ReadAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
