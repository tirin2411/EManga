using Data.EF;
using Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
//using ViewModels.Common;
using System.Threading.Tasks;
using Data.ViewModel;

namespace Application.Common
{
    public class StatisticService : IStatisticService
    {
        private readonly MnDbContext _context;

        public StatisticService(MnDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate)
            };
            return _context.RevenueStatisticViewModels.FromSqlRaw<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters).ToList();

        }

    }
}
