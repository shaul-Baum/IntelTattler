using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    public static class Class1
    {
        public static void InsertNewReport()
        {
            string SecretCode;

            Console.WriteLine("Please enter the Reporter ID:");
            int ReporterId = int.Parse(Console.ReadLine());

            if (!dalPeople.TestId(ReporterId))
            {
                Logger.Log(CreatPeople(id: ReporterId));
            }


            Console.WriteLine("Please enter the Secret Code:");
            SecretCode = Console.ReadLine();

            if (!dalPeople.TestId(SecretCode: SecretCode))
            {
                Logger.Log(dalPeople.newPeople(SecretCode));
            }


            Console.WriteLine("Please enter the Report Text:");
            string ReportText = Console.ReadLine();

            dalReports.NewReport(ReporterId, SecretCode, ReportText);
            

            Console.WriteLine("The report was sent successfully!");


            Aerts.CreateAlert(SecretCode, ReporterId);

            people.AgentCostCheck(ReporterId);
        }

        public static string CreatPeople(int id = -1, string SecretCode = "", string FullName = "")
        {
            if (SecretCode == "")
            {

                Console.WriteLine("Please enter a secret code for the new person:");
                SecretCode = Console.ReadLine();
            }

            if (FullName == "")
            {

                Console.WriteLine("Please enter a full name for the new person:");
                FullName = Console.ReadLine();
            }

            if ((dalPeople.TestId(id)) || id == -1)
            {
                dalPeople.newPeople(SecretCode, FullName);

                return $"New person created with secret code: {SecretCode} and name: {FullName}";
            }

            dalPeople.newPeople(SecretCode, FullName, id);

            return $"New person created with ID: {id}, secret code: {SecretCode} and name: {FullName}";
        }

        public static void menu()
        {
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        InsertNewReport();
                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                }
            }
        }
    }
}