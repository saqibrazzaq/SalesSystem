using Microsoft.EntityFrameworkCore;
using products_api.Models;

namespace products_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions op) : base(op)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Brand 
            modelBuilder.Entity<Brand>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Availability 
            modelBuilder.Entity<Availability>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Network 
            modelBuilder.Entity<Network>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Network  Detail
            modelBuilder.Entity<NetworkBand>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Sim Size
            modelBuilder.Entity<SimSize>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Sim Multiple
            modelBuilder.Entity<SimMultiple>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }



        // Tables
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Availability>? Availabilities { get; set; }
        public DbSet<Network>? Networks { get; set; }
        public DbSet<NetworkBand>? NetworkBands { get; set; }
        public DbSet<SimSize>? SimSizes { get; set; }
        public DbSet<SimMultiple>? SimMultiples { get; set; }
    }
}
