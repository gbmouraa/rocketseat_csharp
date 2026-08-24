using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //ActionResult<Usuario> melhor opcao para tipar um endpoint quando se sabe o retorno

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserJson request)
        {
            return Ok();
        }
    }
}
