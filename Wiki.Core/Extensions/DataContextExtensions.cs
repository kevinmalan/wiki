using System;
using System.Collections.Generic;
using System.Linq;
using Wiki.Common.Enums;
using Wiki.Core.Contexts;
using Wiki.Core.Models;

namespace Wiki.Core.Extensions
{
    public static class DataContextExtensions
    {
        private static DataContext _dataContext;

        public static void Seed(this DataContext dataContext)
        {
            _dataContext = dataContext;

            SeedUserRoles();
            SeedCompanyRoles();
            SeedProjectScopes();

            _dataContext.SaveChanges();
        }

        private static void SeedUserRoles()
        {
            if (_dataContext.UserRole.Any()) return;

            _dataContext.UserRole.AddRange(
                new List<UserRole>
                {
                    new UserRole
                    {
                        Role = SystemRole.Admin,
                        UniqueId = Guid.NewGuid()
                    },
                    new UserRole
                    {
                        Role = SystemRole.Member,
                        UniqueId = Guid.NewGuid()
                    }
                }
              );
        }

        private static void SeedCompanyRoles()
        {
            if (_dataContext.CompanyRole.Any()) return;

            _dataContext.CompanyRole.AddRange(
                new List<Models.CompanyRole>
                {
                    new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Chief,
                        AllowCreateProject = true,
                        UniqueId = Guid.NewGuid()
                    },
                    new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Tier3,
                        AllowCreateProject = false,
                        UniqueId = Guid.NewGuid()
                    },
                    new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Tier2,
                        AllowCreateProject = false,
                        UniqueId = Guid.NewGuid()
                    },
                   new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Tier1,
                        AllowCreateProject = false,
                        UniqueId = Guid.NewGuid()
                    }
                }
              );
        }

        private static void SeedProjectScopes()
        {
            if (_dataContext.ProjectScope.Any()) return;

            _dataContext.ProjectScope.AddRange(
                new List<Models.ProjectScope>
                {
                    new Models.ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Scope = Common.Enums.ProjectScope.Editor
                    },
                    new Models.ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Scope = Common.Enums.ProjectScope.Contributor
                    },
                    new Models.ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Scope = Common.Enums.ProjectScope.Reader
                    }
                }
             );
        }
    }
}