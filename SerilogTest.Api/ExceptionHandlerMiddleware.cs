using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using Serilog;
using System.Net;
using System.Threading.Tasks;

namespace SerilogTest.Api
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            //int statusCode = (int)HttpStatusCode.InternalServerError;
            int statusCode = context.Response.StatusCode;
            var result = JsonConvert.SerializeObject(new
            {
                statusCode = statusCode,
                errorMessage = exception.Message
            });
            Log.Error(exception, "Exception occured");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
