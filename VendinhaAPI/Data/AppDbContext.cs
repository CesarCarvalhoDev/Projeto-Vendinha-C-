using Microsoft.EntityFrameworkCore;
using VendinhaAPI.Models;

namespace VendinhaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Divida> Dividas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

}