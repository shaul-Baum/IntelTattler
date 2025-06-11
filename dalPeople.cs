using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    internal class dalPeople
    {
        public static bool TestId(int id)
        {
            try
            {
                string sql = $"SELECT 1 FROM `people` WHERE ID = {id} or SecretCode = {id};";
                var ServerResponse = DBConnection.Execute(sql);
                if (ServerResponse.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static void newPeople(string SecretCode, string FullName = "anonymous", int id = -1)
        {
            if (id == -1)
            {
                do {
                    Random rnd = new Random();
                    id = rnd.Next(1, 1000); 
                }
                while (TestId(id));
            }

            DateTime CreatedAt = DateTime.Now;
            string sql = "INSERT INTO people (Id, FullName, SecretCode, CreatedAt) " +
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
    }
}
