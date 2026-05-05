using System.Net;

namespace CashFlow.Exceptions
{
    public abstract class CashFlowException : Exception
    {
        protected CashFlowException(string message) : base(message) { }

        public abstract HttpStatusCode GetHttpStatusCode();
        public abstract List<string> GetErrors();
    }
}
