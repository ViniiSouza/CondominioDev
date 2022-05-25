using CondominioDevAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioDevAPI.Context
{
    public class CondominioDbContext : DbContext
    {
        public DbSet<Habitante> Habitante { get; set; }

        public CondominioDbContext(DbContextOptions options) : base(options) {}
    }
}
