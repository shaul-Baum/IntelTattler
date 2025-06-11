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
                string sql = $"SELECT * FROM `aerts` WHERE ID = {id};";
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

            }
            return ServerResponse;
        }
        public static bool TestId(int id)
        {

            return getByID(id).Count > 0;
        }
        public static void NewAerts(int TargetId, DateTime WindowStart,string Reason, DateTime? WindowEnd = null)
        {
            int id;
            do
            {
                Random rnd = new Random();
                id = rnd.Next(1, 1000);
            }
            while (TestId(id));
            string sql;

            if (WindowEnd.HasValue)
            {
                sql = "INSERT INTO aerts (Id, TargetId,WindowStart, WindowEnd, Reason) " +
                 $"VALUES ('{id}', '{TargetId}','{WindowStart:yyyy-MM-dd HH}', '{WindowEnd}', '{Reason}');";
            }
            else
            {

                sql = "INSERT INTO aerts (Id, TargetId,WindowStart,Reason) " +
                     $"VALUES ('{id}', '{TargetId}','{WindowStart:yyyy-MM-dd HH}','{Reason}');";
            }


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
