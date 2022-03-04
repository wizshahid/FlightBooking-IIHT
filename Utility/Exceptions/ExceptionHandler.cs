using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Utility.Exceptions
{
    public class ExceptionHandler
    {
        public static async Task Invoke(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            var message = exception?.Message;

            switch (exception)
            {
                case AuthorizationException :
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;
                case AppException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    message = "There is some problem, please try after some time.";
                    break;
            }
           await context.Response.WriteAsync(message);
        }
    }
}
