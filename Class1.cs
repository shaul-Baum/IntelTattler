//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Mysqlx.Prepare;

//namespace IntelTettler
//{
//    public static class Class1
//    {


//        public static void ReceivingInput()
//        {
//            string SecretCode;
//            Console.WriteLine("");
//            int ReporterId = int.Parse(Console.ReadLine());
//            if (!dalPeople.TestId(ReporterId))
//            {
//                Logger.Log(CreatingPeople(id : ReporterId));
//            }
//            Console.WriteLine("");
//            SecretCode = Console.ReadLine();
//            if (!dalPeople.TestId(SecretCode: SecretCode))
//            {

//                dalPeople.newPeople(SecretCode);
//            }
//            Console.WriteLine("");
//            string ReportText = Console.ReadLine();
//            try
//            {
//                Logger.Log(dalReports.NewReport(ReporterId, SecretCode, ReportText));
//                Console.WriteLine(""); }
//            catch {
//                Console.WriteLine();
//                Logger.Log("");
//            }


//        }
//        public static string CreatingPeople(int id = -1, string SecretCode = "", string FullName = "")
//        {
//            if (SecretCode == "")
//            {
//                Console.WriteLine("");
//                SecretCode = Console.ReadLine();
//            }
//            if (FullName == "")
//            {
//                Console.WriteLine("");
//                FullName = Console.ReadLine();
//            }

//            if ((dalPeople.TestId(id)) || id == -1)
//            {
//                dalPeople.newPeople(SecretCode, FullName);
//                return "";
//            }

//            dalPeople.newPeople(SecretCode, FullName, id);
//            return "";

//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelTettler
{
    public static class Class1
    {
        public static void ReceivingInput()
        {
            string SecretCode;

            Console.WriteLine("Please enter the Reporter ID:");
            int ReporterId = int.Parse(Console.ReadLine());

            if (!dalPeople.TestId(ReporterId))
            {
                Logger.Log(CreatingPeople(id: ReporterId));
            }

      
            Console.WriteLine("Please enter the Secret Code:");
            SecretCode = Console.ReadLine();

            if (!dalPeople.TestId(SecretCode: SecretCode))
            {
                dalPeople.newPeople(SecretCode);
            }

        
            Console.WriteLine("Please enter the Report Text:");
            string ReportText = Console.ReadLine();

            try
            {
             
                Logger.Log(dalReports.NewReport(ReporterId, SecretCode, ReportText));
          
                Console.WriteLine("The report was sent successfully!");
            }
            catch (Exception ex)
            {
     
                Console.WriteLine("An error occurred while sending the report. Please try again.");
      
                Logger.Log($"Error sending report: {ex.Message}");
            }
        }

        public static string CreatingPeople(int id = -1, string SecretCode = "", string FullName = "")
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
    }
}