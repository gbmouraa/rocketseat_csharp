using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId}")]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)] // documenta o retorno do endpoint no swagger/ferramentas padrão OpenApi
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
        public IActionResult Register([FromRoute] Guid clientId, RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();

            var response = useCase.Execute(clientId, request);

            return Created("", response);
        }
    }
}
