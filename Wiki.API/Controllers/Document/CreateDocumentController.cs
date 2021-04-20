using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wiki.Common;
using Wiki.Common.Requests.Document;
using Wiki.Common.Responses;
using Wiki.Common.Responses.Document;
using Wiki.Core.Handler_Requests.Document;

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
        public async Task<IActionResult> CreateDocumentAsync([FromRoute] Guid projectId, [FromBody] CreateDocumentRequest request)
        {
            var docId = await _mediator.Send(new CreateDocumentHandlerRequest
            {
                Name = request.Name,
                Title = request.Title,
                Content = request.Content,
                UniqueProjectId = projectId,
                UniqueUserId = GetUserId()
            });

            return OkApiResponse(new DocumentCreatedResponse
            {
                UniqueId = docId
            });
        }
    }
}