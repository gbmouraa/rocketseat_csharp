using CashFlow.Application.UseCases.User.Register;
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
        public async Task<IActionResult> Register([FromBody] RegisterUserJson request, [FromServices] IRegisterUserUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
