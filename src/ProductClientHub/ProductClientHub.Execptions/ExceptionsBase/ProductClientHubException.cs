using System.Net;

namespace ProductClientHub.Execptions.ExecptionsBase
{   // classe abstrata para as exceptions personalidas
    public abstract class ProductClientHubException : SystemException
    {
        // passa errorMessager para o construtor da classe que está sendo herdada (SystemException)
        public ProductClientHubException(string errorMessage) : base(errorMessage) { }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}