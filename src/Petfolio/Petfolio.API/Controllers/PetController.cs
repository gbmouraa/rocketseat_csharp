using Microsoft.AspNetCore.Mvc;
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
            return Created();
        }
    }
}
