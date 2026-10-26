namespace AccessiblePortal.Middleware;

/// <summary>Logs method/path/status/duration only. Never logs bodies,
/// emails, or any sensitive data — a requirement when handling
/// classified or sensitive government/health data.</summary>
public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;
        await next(context);
        logger.LogInformation("{Method} {Path} -> {Status} in {Ms}ms",
            context.Request.Method, context.Request.Path,
            context.Response.StatusCode, (DateTime.UtcNow - start).TotalMilliseconds);
    }
}
