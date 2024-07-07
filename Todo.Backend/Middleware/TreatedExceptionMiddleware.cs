using Newtonsoft.Json;
using Todo.Backend.TreatmentException;

namespace Todo.Backend.Middleware;

public class TreatedExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public TreatedExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (TreatedException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, new TreatedException("Erro interno do servidor.", 500, ex.Message));
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, TreatedException exception)
    {
        var response = new
        {
            Message = exception.Message,
            ErrorCode = exception.ErrorCode,
            Details = exception.ErrorDetails
        };

        var result = JsonConvert.SerializeObject(response);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception.ErrorCode;

        return context.Response.WriteAsync(result);
    }
}
