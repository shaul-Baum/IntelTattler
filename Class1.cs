using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelTettler
{
    internal class Class1
    {
        //protected bool test_id(int id)
        //{
            
        //    return false;
        //}
        protected void ReceivingInput()
        {
            Console.WriteLine("");
            int ReporterId =int.Parse(Console.ReadLine());
            //test_id(ReporterId);
            Console.WriteLine("");
            int TargetId =int.Parse(Console.ReadLine());
            //test_id(TargetId);
            Console.WriteLine("");
            string ReportText = Console.ReadLine();
        }


    }
}
