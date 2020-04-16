using Mariage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mariage.Data
{
    public class MariageDbContext : IdentityDbContext<MariageUser>
    {
        public MariageDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Participation> Participations { get; set; } = null!;
    }
}