using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelTettler
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(dalPeople.TestId(345));
            dalPeople.newPeople(345, "qryi");
            Console.WriteLine(dalPeople.TestId(345));
        }
    }
}
