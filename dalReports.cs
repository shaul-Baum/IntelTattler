using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    internal class dalReports
    {

        public static List<Dictionary<string, object>> getBySecretCode(string SecretCode)
        {
            List<Dictionary<string, object>> ServerResponse = new List<Dictionary<string, object>>();
            try
            {
                string sql = $"SELECT * FROM `reports` WHERE SecretCode = '{SecretCode}';";
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
                return ServerResponse;
            }
        }
        public static List<Dictionary<string, object>> getByID(int id =-1,int ReporterId =-1)
        {
            List<Dictionary<string, object>> ServerResponse = new List<Dictionary<string, object>>();
            string sql;
            if (id == -1)
            {
                sql = $"SELECT * FROM `reports` WHERE  ReporterId = {ReporterId};";
            }
            else
            {
                sql = $"SELECT * FROM `reports` WHERE  Id = {id};";
            }
            try
            {
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
                return ServerResponse;
            }
        }
        public static bool TestId(int id)
        {

            return getByID(id:id).Count > 0;
        }
        public static string NewReport(int ReporterId, string SecretCode, string ReportText)
        {
            int id = 0;
            do
            {
                Random rnd = new Random();
                id = rnd.Next(1, 1000);
            }
            while (TestId(id));

            //DateTime CreatedAt = DateTime.Now;
            string sql = "INSERT INTO reports (Id,ReporterId,SecretCode,ReportText) " +
                 $"VALUES ('{id}', '{ReporterId}', '{SecretCode}', '{ReportText}');";
            try
            {
                int a = DBConnection.InsertRow(sql);
                Logger.Log($"New alert created successfully in SQL: ID={id}, ReporterId={ReporterId}, SecretCode={SecretCode}, ReportText={ReportText}");
                return ($"New alert created successfully in SQL: ID={id}, ReporterId={ReporterId}, SecretCode={SecretCode}, ReportText={ReportText}");
            }
            catch (Exception ex)
            {
                Logger.Log("");
                return "Error inserting person:" + ex.Message;
            }
        }
    }
}
