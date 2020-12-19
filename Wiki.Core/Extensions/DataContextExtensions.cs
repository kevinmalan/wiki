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
                        Name = UserRoleName.Admin,
                        UniqueId = Guid.NewGuid()
                    },
                    new UserRole
                    {
                        Name = UserRoleName.Member,
                        UniqueId = Guid.NewGuid()
                    }
                }
              );
        }

        private static void SeedProjectScopes()
        {
            if (_dataContext.ProjectScope.Any()) return;

            _dataContext.ProjectScope.AddRange(
                new List<ProjectScope>
                {
                    new ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Name = ProjectScopeName.ReadDocument
                    },
                    new ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Name = ProjectScopeName.CreateDocument
                    },
                    new ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Name = ProjectScopeName.EditDocument
                    },
                    new ProjectScope
                    {
                        UniqueId = Guid.NewGuid(),
                        Name = ProjectScopeName.DeleteDocument
                    }
                }
             );
        }
    }
}