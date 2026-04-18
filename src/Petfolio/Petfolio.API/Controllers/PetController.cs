using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status201Created)]
        public ActionResult Register([FromBody] RequestPetJson request)
        {
            var useCase = new RegisterPetUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
