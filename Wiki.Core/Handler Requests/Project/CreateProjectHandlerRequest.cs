using System;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateProjectHandlerRequest
    {
        public string Name { get; set; }
        public Guid CompanyUniqeId { get; set; }
        public Guid CreatorUniqueId { get; set; }
    }
}