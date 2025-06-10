using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Prepare;

namespace IntelTettler
{
    public static class Class1
    {


        public static void ReceivingInput()
        {
            Console.WriteLine("");
            int ReporterId = int.Parse(Console.ReadLine());
            if (!dalPeople.TestId(ReporterId))
            {
                Console.WriteLine("");
                string SecretCode = Console.ReadLine();
                Console.WriteLine("");
                string FullName = Console.ReadLine();
                dalPeople.newPeople(ReporterId, SecretCode, FullName);
            }
            Console.WriteLine("");
            int SecretCode = int.Parse(Console.ReadLine());
            if (!dalPeople.TestId(SecretCode))
            {

                dalPeople.newPeople(TargetId, SecretCode);
            }
            Console.WriteLine("");
            string ReportText = Console.ReadLine();
        }


    }
}
