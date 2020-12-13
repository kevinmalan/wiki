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
        public static void Seed(this DataContext dataContext)
        {
            SeedUserRoles(dataContext);
            SeedCompanyRoles(dataContext);
        }

        private static void SeedUserRoles(DataContext dataContext)
        {
            if (dataContext.UserRole.Any()) return;

            dataContext.UserRole.AddRange(
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

            dataContext.SaveChanges();
        }

        private static void SeedCompanyRoles(DataContext dataContext)
        {
            if (dataContext.CompanyRole.Any()) return;

            dataContext.CompanyRole.AddRange(
                new List<Models.CompanyRole>
                {
                    new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Editor,
                        UniqueId = Guid.NewGuid()
                    },
                    new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Contributor,
                        UniqueId = Guid.NewGuid()
                    },
                    new Models.CompanyRole
                    {
                        Role = Common.Enums.CompanyRole.Reader,
                        UniqueId = Guid.NewGuid()
                    }
                }
              );

            dataContext.SaveChanges();
        }
    }
}