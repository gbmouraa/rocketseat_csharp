using CashFlow.Application.UseCases.User.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserCreated), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        //melhor opcao para tipar um endpoint quando se sabe o retorno
        public async Task<ActionResult<ResponseUserCreated>> Register([FromBody] RegisterUserJson request, [FromServices] IRegisterUserUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }
    }
}
