using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Kernel.Exceptions.Handler;

public class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (title, detail, statusCode) = exception switch
        {
            NotFoundException ex => ("Ресурс не найден", ex.Message, StatusCodes.Status404NotFound),
            _ => ("Внутренняя ошибка сервера", "Произошла непредвиденная ошибка.", StatusCodes.Status500InternalServerError)
        };
        
        httpContext.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Status = statusCode,
            Instance = httpContext.Request.Path
        };
        
        problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}