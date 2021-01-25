using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ExceptionTesing.Api
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILog logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex, logger).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception, ILog logger)
        {
            context.Response.ContentType = "application/json";
            //int statusCode = (int)HttpStatusCode.InternalServerError;
            int statusCode = context.Response.StatusCode;
            var result = JsonConvert.SerializeObject(new
            {
                statusCode = statusCode,
                errorMessage = exception.Message
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            logger.Error(exception.ToString());
            return context.Response.WriteAsync(result);
        }
    }
}
