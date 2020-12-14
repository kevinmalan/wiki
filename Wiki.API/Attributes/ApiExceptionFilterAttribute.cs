using Wiki.Common.Exceptions;
using Wiki.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Wiki.API.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequest br)
            {
                var apiResponse = new ApiResponse<BadRequest>
                {
                    Error = GetError(br.Message)
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(apiResponse);
            }
            else if (context.Exception is NotFound nf)
            {
                var apiResponse = new ApiResponse<NotFound>
                {
                    Error = GetError(nf.Message)
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(apiResponse);
            }
            else if (context.Exception is UnAuthorized ua)
            {
                var apiResponse = new ApiResponse<UnAuthorized>
                {
                    Error = GetError(ua.Message)
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(apiResponse);
            }
            else
            {
                var apiResponse = new ApiResponse<BadRequest>
                {
                    Error = GetError("Something bad happened. Please contact customer support.")
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(apiResponse);
            }

            context.ExceptionHandled = true;
            //base.OnException(context);
        }

        private Error GetError(string message)
        {
            return new Error
            {
                Message = message
            };
        }
    }
}