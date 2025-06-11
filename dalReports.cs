using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    internal class dalReports
    {
        public static List<Dictionary<string, object>> getByID(int id)
        {
            List<Dictionary<string, object>> ServerResponse = new List<Dictionary<string, object>>();
            try
            {
                string sql = $"SELECT * FROM `reports` WHERE ID = {id};";
                ServerResponse = DBConnection.Execute(sql);
                Logger.Log("");
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
                    Console.WriteLine("");
                }
                Console.WriteLine("Error inserting person:");
                Console.WriteLine(ex.Message);
                return ServerResponse;
            }
        }
        public static bool TestId(int id)
        {
            return getByID(id).Count > 0;
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

            DateTime CreatedAt = DateTime.Now;
            string sql = "INSERT INTO reports (Id,ReporterId,SecretCode,ReportText) " +
                 $"VALUES ('{id}', '{ReporterId}', '{SecretCode}', '{ReportText}');";
            try
            {
                int a = DBConnection.InsertRow(sql);
                Logger.Log("");
                return ("");
            }
            catch (Exception ex)
            {
                Logger.Log("");
                return "Error inserting person:" + ex.Message;
            }
        }
    }
}
