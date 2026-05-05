using System.Net;

namespace CashFlow.Exceptions
{
    public class ErrorOnValidationException : CashFlowException
    {
        public List<string> Errors { get; set; }

        public ErrorOnValidationException(List<string> messages) : base(string.Empty)
        {
            Errors = messages;
        }

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
        public override List<string> GetErrors() => Errors;
    }
}
