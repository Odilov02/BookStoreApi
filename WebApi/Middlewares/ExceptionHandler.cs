namespace WebApi.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    public ExceptionHandler(RequestDelegate next) => _next = next;
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await HandlerException(context, HttpStatusCode.NotFound, ex, ex.Message);
        }
    }
    async Task HandlerException<TException>(HttpContext context, HttpStatusCode statusCode, TException ex, string message)
    {
        var respone = new ResponseCore<TException>()
        {
            Errors = new string[] { message },
            Result = ex,
            StatusCode = statusCode,
            IsSuccess = false
        };
        string result = JsonSerializer.Serialize(respone);
        await context.Response.WriteAsJsonAsync(result);
    }
}

static class MyClass
{

    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandler>();
    }
}
