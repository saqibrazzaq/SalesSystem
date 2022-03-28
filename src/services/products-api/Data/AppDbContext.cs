using Microsoft.EntityFrameworkCore;
using products_api.Models;

namespace products_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions op) : base(op)
        {

        }

        // Tables
        public DbSet<Category>? Categories { get; set; }
    }
}
