namespace CashFlow.Communication.Responses
{
    public class ResponseErrorMessageJson
    {
        public List<string> Errors { get; set; }

        public ResponseErrorMessageJson(string error)
        {
            Errors = new List<string> { error };
        }

        public ResponseErrorMessageJson(List<string> errors)
        {
            Errors = errors;
        }
    }
}
