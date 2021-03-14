using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<UserRoleCompanyMap> UserCompanyRoleMap { get; set; }
        public ICollection<UserProjectScopeMap> UserProjectScopeMap { get; set; }
    }
}