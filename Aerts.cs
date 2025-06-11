using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelTettler
{
    internal class Aerts
    {
        public static void CreateAlert(int id)
        {
            if (dalReports.getByID(id).Count > 15)
            {
                dalPeople.SuspicionLevel(id);
                DateTime time = DateTime.Now;
                string Reason = "";
                DalaAerts.NewAerts(id, time, Reason);
            }
        }
    }
}
