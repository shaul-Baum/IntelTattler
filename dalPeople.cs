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
                string sql = $"SELECT 1 FROM `people` WHERE ID = '{id}' or SecretCode = '{id}';";
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
        public static void newPeople(string SecretCode, string FullName = "anonymous", int id = -1)
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
            string sql = "INSERT INTO `people` (Id, FullName, SecretCode, CreatedAt) " +
                 $"VALUES ('{id}', '{FullName}', '{SecretCode}', '{CreatedAt}');";
            try
            {
                int a = DBConnection.InsertRow(sql);
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
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
    }
}
