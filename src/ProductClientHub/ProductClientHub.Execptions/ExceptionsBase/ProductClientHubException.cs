namespace ProductClientHub.Execptions.ExecptionsBase
{
    public abstract class ProductClientHubException : SystemException
    {
        // passa errorMessager para o construtor da classe que está sendo herdada (SystemException)
        public ProductClientHubException(string errorMessage) : base(errorMessage)
        {

        }

        public abstract List<string> GetErrors();
    }
}