using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetExcel([FromHeader] DateOnly month)
        {
            byte[] file = new byte[4];

            if (file.Length > 0)
                return File(file, MediaTypeNames.Application.Octet, "report.xlsx");

            return NoContent();
        }
    }
}
