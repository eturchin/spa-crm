using System.Net;
using FluentValidation;
using Newtonsoft.Json;

namespace SpaCRM.Middleware;

public class CrmExceptionHandlerMiddleware(RequestDelegate next, ILogger<CrmExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode;
        string text;
        switch (exception)
        {
            case ValidationException validationException:
                httpStatusCode = HttpStatusCode.NotAcceptable;
                text = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case AccessViolationException validationException:
                httpStatusCode = HttpStatusCode.Forbidden;
                text = JsonConvert.SerializeObject(validationException.Message);
                break;
            default:
                httpStatusCode = HttpStatusCode.InternalServerError;
                logger.LogError(exception, exception!.Message);
                text = JsonConvert.SerializeObject(new {Error = exception.Message});
                break;
              
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(text);
    }
}