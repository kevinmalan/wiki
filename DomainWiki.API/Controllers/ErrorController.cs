using DomainWiki.API.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DomainWiki.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var httpStatus = HttpStatusCode.BadRequest;
            string message;

            switch (exception)
            {
                case NotFound _:
                    httpStatus = (exception as NotFound).Code;
                    message = exception.Message;
                    break;

                case BadRequest _:
                    httpStatus = (exception as BadRequest).Code;
                    message = exception.Message;
                    break;

                default:
                    message = "Something went wrong. Please contact customer support on xxx-xx-xxx";
                    break;
            }

            Response.StatusCode = (int)httpStatus;

            return new ErrorResponse
            {
                StatusCode = (int)httpStatus,
                StatusCodeName = httpStatus.ToString(),
                Message = message
            };
        }
    }
}