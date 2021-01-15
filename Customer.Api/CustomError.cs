using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api
{
    public class CustomError
    {
        public CustomError(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public CustomError()
        {

        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
