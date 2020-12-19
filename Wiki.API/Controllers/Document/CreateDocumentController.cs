using Wiki.Common;
using Wiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wiki.Common.Requests.Project;
using Wiki.Core.Handler_Requests.Project;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace Wiki.API.Controllers.Document
{
    [Authorize]
    public class CreateDocumentController : BaseController
    {
        private readonly IMediator _mediator;

        public CreateDocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Document.Create)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDocumentAsync([FromRoute] Guid projectUniqueId)
        {
            return OkEmptyApiResponse();
        }
    }
}