using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    internal class DalaAerts
    {
        public static List<Dictionary<string, object>> getByID(int id)
        {
            List<Dictionary<string, object>> ServerResponse = new List<Dictionary<string, object>>();
            try
            {
                string sql = $"SELECT * FROM `alerts` WHERE ID = {id};";
                ServerResponse = DBConnection.Execute(sql);
                Logger.Log("Retrieving data from sql was successful.");
                return ServerResponse;

            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Log("Error inserting person:" + ex.Message);
                }
                catch
                {
                    Console.WriteLine("Writing to log file failed");
                }
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);

            }
            return ServerResponse;
        }
        public static bool TestId(int id)
        {

            return getByID(id).Count > 0;
        }
        public static void NewAerts(int TargetId,string Reason)
        {
            int id;
            do
            {
                Random rnd = new Random();
                id = rnd.Next(1, 1000);
            }

            while (TestId(id));



            string sql = "INSERT INTO alerts (Id, TargetId, WindowStart, WindowEnd, Reason, CreatedAt) " +
             $"VALUES ('{id}', '{TargetId}', NOW(), NULL, '{Reason}', NOW());";


            try
            {
                int a = DBConnection.InsertRow(sql);
                Logger.Log("Retrieving data from sql was successful.");
                Console.WriteLine("Retrieving data from sql was successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
            }
        }
       
    }
}
