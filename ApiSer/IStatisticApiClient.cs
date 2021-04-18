using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiSer
{
    public interface IStatisticApiClient
    {
        Task<IEnumerable<RevenueStatisticViewModel>> GetRevenueStatistic(string fromDate, string toDate);
    }
}
