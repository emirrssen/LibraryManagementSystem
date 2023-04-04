using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Exceptions.Base;

namespace Core.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExceptionBase ex)
            {
                await HandleException(context, ex.Message, ex.StackTrace, ex.StatusCode);
            }
            catch (Exception exception)
            {
                await HandleException(context, exception.Message, exception.StackTrace);
            }
        }

        public Task HandleException(HttpContext context, string message, string? stackTrace,
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            HttpStatusCode httpStatus = httpStatusCode;

            if (httpStatusCode == default)
                httpStatus = HttpStatusCode.InternalServerError;

            var resultException = JsonSerializer.Serialize(new
            {
                Error = message,
                StatusCode = (int)httpStatus,
                Title = "Unknown error!"
            });

            context.Response.StatusCode = (int)httpStatus;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(resultException);
        }
    }
}
