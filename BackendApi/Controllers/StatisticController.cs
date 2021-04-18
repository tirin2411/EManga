using Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels.Common;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("getrevenue")]
        public IActionResult GetRevenueStatistic(string fromDate, string toDate)
        {
            var orders = _statisticService.GetRevenueStatistic(fromDate, toDate);
            return Ok(orders);
        }
    }
}
