using ApiSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticApiClient _statisticApiClient;

        public StatisticController(IStatisticApiClient statisticApiClient)
        {
            _statisticApiClient = statisticApiClient;
        }
        public async Task<IActionResult> Revenue(string fromDate, string toDate)
        {
            var data = await _statisticApiClient.GetRevenueStatistic(fromDate, toDate);
            return Ok(data);
        }
    }
}
