using CashFlow.Communication.Responses;
using CashFlow.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var ex = (CashFlowException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)ex.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessageJson(ex.GetErrors()));
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessageJson("ERRO DESCONHECIDO"));
        }
    }
}
