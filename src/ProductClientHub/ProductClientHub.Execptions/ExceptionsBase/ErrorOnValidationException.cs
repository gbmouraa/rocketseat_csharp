using ProductClientHub.Execptions.ExecptionsBase;
using System.Net;

namespace ProductClientHub.Execptions.ExceptionsBase
{
    public class ErrorOnValidationException : ProductClientHubException
    {   // readonly serve para permitir que seja atribuido um valor somente no construtor
        private readonly List<string> _erros;

        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _erros = errorMessages;
        }

        // override para sobescrever o método da classe herdada
        public override List<string> GetErrors() => _erros;

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;

    }
}
