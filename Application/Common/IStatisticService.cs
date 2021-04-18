using Data.Entities;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//using ViewModels.Common;

namespace Application.Common
{
    public interface IStatisticService
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);

    }
}
