using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Common.Enums;

namespace Wiki.Core.Models
{
    public class CompanyRole
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Common.Enums.CompanyRole Role { get; set; }
    }
}