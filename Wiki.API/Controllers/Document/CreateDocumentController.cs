using Wiki.Common;
using Wiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wiki.Common.Requests.Project;
using Wiki.Core.Handler_Requests.Project;
using System;
using Wiki.API.Filters;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using Wiki.API.Filters.ProjectScope;

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
        [ServiceFilter(typeof(HasCompanyConnectionFilter))]
        [ServiceFilter(typeof(HasProjectScopePrivilegeFilter))]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDocumentAsync([FromRoute] Guid projectUniqueId)
        {
            return OkEmptyApiResponse();
        }
    }
}