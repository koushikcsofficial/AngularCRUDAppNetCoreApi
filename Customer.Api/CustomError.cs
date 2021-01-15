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
            status = statusCode;
            title = message;
        }
        public CustomError()
        {

        }
        public int status { get; set; }
        public string title { get; set; }
    }
}
