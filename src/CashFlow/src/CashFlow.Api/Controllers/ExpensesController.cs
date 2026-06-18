using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public ActionResult Register([FromBody] RequestRegisterExpenseJson request,
            [FromServices] IRegisterExpenseUseCase useCase) // uma das possibilidades de usar um serviço
        {
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
