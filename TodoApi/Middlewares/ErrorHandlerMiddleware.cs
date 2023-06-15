using System.Net;
using System.Text.Json;
using TodoApi.Exeptions;

namespace TodoApi.Middlewares;

public sealed class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;

        if (exception is TodoException) statusCode = HttpStatusCode.BadRequest;

        var response = JsonSerializer.Serialize(new
        {
            Success = false,
            StatusCode = statusCode,
            Errors = GetExceptions(exception).Select(e => e.Message)
        });

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(response);
    }

    private IEnumerable<Exception> GetExceptions(Exception ex)
    {
        yield return ex;
        while (ex.InnerException is not null)
        {
            yield return ex.InnerException;
            ex = ex.InnerException;
        }
    }
}