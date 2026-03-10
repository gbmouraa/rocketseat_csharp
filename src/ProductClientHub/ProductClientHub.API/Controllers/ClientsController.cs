using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Execptions.ExecptionsBase;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)] // documenta o retorno do endpoint no swagger/ferramentas padrão OpenApi
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(request); // executa a requisição - valida os dados - lança exeção

                return Created(string.Empty, response);
            }
            catch (ProductClientHubException ex) // captura a exeção definida no useCase
            {
                var errors = ex.GetErrors();
                return BadRequest(new ResponseErrorMessageJson(errors));
            }
            catch // captura qualquer outra exeção
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessageJson("ERRO DESCONHECIDO"));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
