namespace SerilogTest.Api
{
    public class CustomError
    {
        public CustomError(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.ErrorMessage = message;
        }
        public CustomError()
        {

        }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}