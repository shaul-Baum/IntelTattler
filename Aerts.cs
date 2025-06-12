using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelTettler
{
    internal class Aerts
    {
        public static void CreateAlert(string SecretCode ,int ReporterId)
        {
            if (dalReports.getBySecretCode(SecretCode).Count > 1)
            {
                int id = dalPeople.gatIdBySecretCode(SecretCode);
                dalPeople.SuspicionLevel(id);
                string Reason = "";
                DalaAerts.NewAerts(id,Reason);

                dalPeople.AddingSuspect(id);
               

            }

           
        }
    }
}
