using AutoMapper;
using Bsynchro.Contracts.BO;
using Bsynchro.Contracts.BO.Errors;
using Bsynchro.Contracts.IServices;
using Bsynchro.Contracts.Repos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bsynchro.API.MiddleWares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public GlobalErrorHandlerMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory= serviceScopeFactory;  
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Log the exception to the database
                var error = new ErrorBO
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ErrorType = ex.GetType().Name,
                    DateCreated = DateTime.UtcNow
                };

                // Resolve the Error service from the scope
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var errorService = scope.ServiceProvider.GetRequiredService<IErrorService>();
                    await errorService.Create(error);
                }

                // Return error response
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var errorResponse = new ErrorResponseBO
                {
                    ErrorId= error.ErrorId.ToString(),
                    ErrorMessage = "An unexpected error occurred. Please try again later."
                };
                var jsonResponse = JsonSerializer.Serialize(errorResponse);
                await httpContext.Response.WriteAsync(jsonResponse);

                logger.LogError(ex, "An unhandled exception has occurred.");
            }
        }
    }

}
