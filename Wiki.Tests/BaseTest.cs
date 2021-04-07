using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Xunit;

namespace Wiki.Tests
{
    public class BaseTest
    {
        protected static DataContext Db()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            return new DataContext(options);
        }
    }
}