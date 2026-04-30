using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        public ActionResult Register([FromBody] RequestExpenseJson request)
        {
            return Ok();
        }
    }
}
