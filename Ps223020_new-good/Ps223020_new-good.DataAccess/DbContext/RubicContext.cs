using System;
using System.Collections.Generic;
using System.Text;
using Ps223020_new_good.DataAcess.Core.Models;
using Microsoft.EntityFrameworkCore;
using Ps223020_new_good.DataAcess.Core.Interfaces.DbContext;
using System.Threading.Tasks;
using System.Threading;

namespace Ps223020_new_good.DataAccess.DbContext
{
    public class RubicContext : Microsoft.EntityFrameworkCore.DbContext, IRubicContext
    {
        public RubicContext(DbContextOptions<RubicContext> options)
            : base(options)
        {

        }
        public DbSet<UserRto> Users { get; set; }
        public DbSet<UserRoleRto> UserRoles { get; set; }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
