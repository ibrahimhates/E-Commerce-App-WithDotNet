using Entity.ErrorModel;
using Entity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Service.Abstracts.LoggerAbstract;
using System.Net;

namespace Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
            ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetail()
                        {
                            ErrorMessage = contextFeature.Error.Message,
                            StatusCode = context.Response.StatusCode
                        }.ToString());
                    }
                });
            });
        }
    }
}
