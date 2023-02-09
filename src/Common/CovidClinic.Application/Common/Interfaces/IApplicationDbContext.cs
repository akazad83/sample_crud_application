using System.Threading;
using System.Threading.Tasks;
using CovidClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovidClinic.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
