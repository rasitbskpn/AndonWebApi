using AndonWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndonWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Display> Displays { get; set; }
    }
}