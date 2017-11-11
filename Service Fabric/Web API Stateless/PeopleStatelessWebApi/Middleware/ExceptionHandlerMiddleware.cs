using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PeopleStatelessWebApi.Middleware
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
                await _next(context);
            }
            catch (Exception ex)
            {
                try
                {
                    await HandleExceptionAsync(context, ex);
                }
                catch
                {
                    throw new Exception($"HandleExceptionAsync could not handle this: {ex}");
                }
            }
        }


        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;                  // Status Code 500 - default unexpected

            switch (ex.GetType().ToString())
            {
                case "System.ArgumentNullException":
                case "System.ArgumentException":
                    code = HttpStatusCode.BadRequest;                       // Status Code 400
                    break;

                // Add custom exceptions here and the status code they should have attributed to them

                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
            return;
        }
    }
}
