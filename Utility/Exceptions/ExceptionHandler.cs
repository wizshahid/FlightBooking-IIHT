using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utility.Exceptions
{
    public class ExceptionHandler
    {
        public static async Task Invoke(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            var errors = new List<AppError>();

            switch (exception)
            {
                case AuthorizationException :
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    errors.Add(new AppError { Message = exception?.Message });
                    break;
                case AppException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    errors.Add(new AppError { Message = exception?.Message });
                    break;
                case AppValidationException ve:
                    errors = ve.Errors;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    errors.Add(new AppError { Message = "There is some problem, please try after some time." });
                    break;
            }
           await context.Response.WriteAsync(JsonConvert.SerializeObject(errors));
        }
    }
}
