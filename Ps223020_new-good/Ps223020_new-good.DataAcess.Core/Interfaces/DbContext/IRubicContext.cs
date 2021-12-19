using Microsoft.EntityFrameworkCore;
using Ps223020_new_good.DataAcess.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ps223020_new_good.DataAcess.Core.Interfaces.DbContext
{
    public interface IRubicContext : IDisposable, IAsyncDisposable
    {
        DbSet<UserRto> Users { get; set; }
        DbSet<UserRoleRto> UserRoles { get; set; }
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    }
}
