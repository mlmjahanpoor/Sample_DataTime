using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample_DateTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var calculate = new Calculate();
            var holidays = new List<DateTime>
            {
                DateTime.Now.AddDays(-5),
                DateTime.Now.AddDays(-2)
            };
            var result = calculate.GetTotalLeavesWithoutHolidays(holidays);

            return Ok(result);
        }
    }
}
