using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mariage.Data
{
    public class MariageDbContext : IdentityDbContext
    {
        public MariageDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}