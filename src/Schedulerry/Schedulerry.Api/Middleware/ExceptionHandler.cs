using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Schedulerry.Common.Errors.Exceptions;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(
            RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestException e)
            {
                await HandleException(context, e);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private Task HandleException(HttpContext context, BadRequestException e)
        {
            string result = JsonConvert.SerializeObject(e.Errors);
            int statusCode = (int)BadRequestException.ErrorCode;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(result);
        }

        private Task HandleException(HttpContext context, Exception e)
        {
            string result = JsonConvert.SerializeObject(e.Message);
            int statusCode = 500;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
