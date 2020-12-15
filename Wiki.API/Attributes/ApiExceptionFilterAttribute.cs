using Wiki.Common.Exceptions;
using Wiki.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Wiki.API.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ExceptionContext _context;

        public override void OnException(ExceptionContext context)
        {
            _context = context;

            switch (context.Exception)
            {
                case BadRequestException br:
                    ToErrorResponse(HttpStatusCode.BadRequest, br.Message);
                    break;

                case NotFoundException nf:
                    ToErrorResponse(HttpStatusCode.NotFound, nf.Message);
                    break;

                case UnAuthorizedException ua:
                    ToErrorResponse(HttpStatusCode.Unauthorized, ua.Message);
                    break;

                default:
                    ToErrorResponse(HttpStatusCode.BadRequest, "Something bad happened. Please contact customer support.");
                    break;
            }
        }

        public void ToErrorResponse(HttpStatusCode code, string message)
        {
            _context.HttpContext.Response.StatusCode = (int)code;
            _context.Result = new JsonResult(ApiResponse.ToError(message));
            _context.ExceptionHandled = true;
        }
    }
}