using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Prepare;

namespace IntelTettler
{
    public static class Logger
    {
        private static string logPath = "C:/Users/user1/source/repos/ConsoleApp9/ConsoleApp9/log.txt"; 
        

        public static void Log(string message)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(logPath, line + Environment.NewLine);
        }
    }
}
