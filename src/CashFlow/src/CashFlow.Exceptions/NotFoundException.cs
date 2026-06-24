using System.Net;

namespace CashFlow.Exceptions
{
    public class NotFoundException : CashFlowException
    {
        public NotFoundException(string message) : base(message) { }

        public override List<string> GetErrors() => new List<string> { Message };
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}