using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelTettler
{
    internal static class people
    {
        public static void AgentCostCheck(int ReporterId)
        {
            if (dalReports.getByID(ReporterId: ReporterId).Count > 1)
            {
                dalPeople.AddGoodAgent(ReporterId);
            }
        }
    }
}
