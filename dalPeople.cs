using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    internal class dalPeople
    {
        public static bool TestSecretCode(string SecretCode)
        {
            try
            {
                string sql = $"SELECT 1 FROM `people` WHERE SecretCode = '{SecretCode}';";
                var ServerResponse = DBConnection.Execute(sql);
                Logger.Log("");
                return ServerResponse.Count > 0;
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Log("Error inserting person:" + ex.Message);
                }
                catch
                {
                    Console.WriteLine("1111111111");
                }
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool TestId(int? id = null, string SecretCode = null)
        {
            try
            {
                string sql = $"SELECT 1 FROM `people` WHERE ID = '{id}' or SecretCode = '{SecretCode}';";
                var ServerResponse = DBConnection.Execute(sql);
                Logger.Log("");
                return ServerResponse.Count > 0;
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Log("Error inserting person:" + ex.Message);
                }
                catch
                {
                    Console.WriteLine("1111111111");
                }
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static string newPeople(string SecretCode, string FullName = "anonymous", int id = -1)
        {
            if (id == -1)
            {
                do
                {
                    Random rnd = new Random();
                    id = rnd.Next(1, 1000);
                }
                while (TestId(id));
            }



            while (TestSecretCode(SecretCode))
            {
                Random rnd = new Random();
                SecretCode = rnd.Next(1, 1000).ToString();

            }


            DateTime CreatedAt = DateTime.Now;

            string formattedDate = CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "INSERT INTO `people` (Id, FullName, SecretCode, CreatedAt) " +
                 $"VALUES ('{id}', '{FullName}', '{SecretCode}', '{formattedDate}');";
            try
            {
                int a = DBConnection.InsertRow(sql);
                Console.WriteLine($"New person created with ID: {id}, secret code: {SecretCode} and name: {FullName}");
                Logger.Log($"New person created with ID: {id}, secret code: {SecretCode} and name: {FullName}");
                return $"New person created with ID: {id}, secret code: {SecretCode} and name: {FullName}";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
                Logger.Log($"Error inserting person: {ex.Message}");
                return $"Error inserting person: {ex.Message}";
            }
        }
        public static void SuspicionLevel(int id)
        {
            try
            {
                string sql = $"UPDATE people SET SuspicionLevel = 'Dangerous' WHERE ID = '{id}';";
                DBConnection.Execute(sql);
                Logger.Log("");
            }
            catch (Exception ex)
            {
                Logger.Log("Error inserting person:" + ex.Message);
            }
        }
        public static int gatIdBySecretCode(string SecretCode)
        {
            List<Dictionary<string, object>> ServerResponse = new List<Dictionary<string, object>>();
            try
            {
                string sql = $"SELECT * FROM `people` WHERE SecretCode = '{SecretCode}';";
                ServerResponse = DBConnection.Execute(sql);
                int id = Convert.ToInt32(ServerResponse[0]["Id"]);
                Logger.Log("Retrieving data from sql was successful.");
                return id;


            }
            catch (Exception ex)
            {

                Logger.Log("Error inserting person:" + ex.Message);
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("111111111111111111111111111111111111111111111111111111111111111111111111111");
                return -1;
            }
        }
        public static string AddingSuspect(int id)
        {
            string sql = $"UPDATE `people` SET SuspicionLevel = 'High' WHERE Id = '{id}';";
            try
            {
                int a = DBConnection.InsertRow(sql);
                Console.WriteLine($"Suspicion level updated to High for ID:{id}");
                Logger.Log($"Suspicion level updated to High for ID:{id}");
            
                return $"Suspicion level updated to High for ID:{id}";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating SuspicionLevel:");
                Console.WriteLine(ex.Message);
    
                Logger.Log($"Error updating SuspicionLevel: {ex.Message}");

                return $"Error updating SuspicionLevel: {ex.Message}";
            }

        }
        public static string AddGoodAgent(int id)
        {
            DateTime CreatedAt = DateTime.Now;

            string sql = $"UPDATE `people` SET AgentEffectiveness = 'Recommended agent' WHERE Id = '{id}';";
            try
            {
                int a = DBConnection.InsertRow(sql);
                Console.WriteLine($"Suspicion level set to 'Trusted Agent' for ID: {id}");
                Logger.Log($"Suspicion level set to 'Trusted Agent' for ID: {id}");
                return $"Suspicion level set to 'Trusted Agent' for ID: {id}";
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("An error occurred while updating AgentEffectiveness:");
                Console.WriteLine(ex.Message);

                Logger.Log($"Error updating AgentEffectiveness: {ex.Message}");

                return $"Error updating AgentEffectiveness: {ex.Message}";
            }

        }
    }
}
