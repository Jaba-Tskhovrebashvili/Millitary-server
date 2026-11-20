using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
public class NotFoundException(string message) : Exception(message);
public class BadRequestException(string message) : Exception(message);
public class ConflictException(string message) : Exception(message);


namespace MillitaryService.Exceptions
{
    public sealed class GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger,
        IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            var (status, title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, "Resource not found"),
                BadRequestException => (StatusCodes.Status400BadRequest, "Bad request"),
                ConflictException => (StatusCodes.Status409Conflict, "Conflict"),
                UnauthorizedAccessException => (StatusCodes.Status403Forbidden, "Forbidden"),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
            };

            if (status == StatusCodes.Status500InternalServerError)
            {
                // ნამდვილი ბაგი: სრული stack trace
                logger.LogError(exception, "Unhandled exception for {Method} {Path}",
                    httpContext.Request.Method, httpContext.Request.Path);
            }
            else
            {
                // მოსალოდნელი შეცდომა: მხოლოდ მოკლე შეტყობინება
                logger.LogWarning("{Method} {Path} -> {Status}: {Message}",
                    httpContext.Request.Method, httpContext.Request.Path, status, exception.Message);
            }

            httpContext.Response.StatusCode = status;

            var problemDetails = new ProblemDetails
            {
                Status = status,
                Title = title,
                // Never leak internal messages for unexpected (500) errors
                Detail = status == StatusCodes.Status500InternalServerError ? null : exception.Message
            };

            // Keep the same fields your frontend already uses
            problemDetails.Extensions["success"] = false;
            problemDetails.Extensions["message"] = status == StatusCodes.Status500InternalServerError
                ? "An unexpected error occurred"
                : exception.Message;

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails
            });
        }
    }
}
