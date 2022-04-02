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

            // BodyFormFactor
            modelBuilder.Entity<BodyFormFactor>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // BodyIpCertificate
            modelBuilder.Entity<BodyIpCertificate>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // BackMaterial
            modelBuilder.Entity<BackMaterial>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // FrameMaterial
            modelBuilder.Entity<FrameMaterial>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // OS
            modelBuilder.Entity<OS>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // OSVersion
            modelBuilder.Entity<OSVersion>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Chipset
            modelBuilder.Entity<Chipset>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // CardSlot
            modelBuilder.Entity<CardSlot>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // DisplayTechnology
            modelBuilder.Entity<DisplayTechnology>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Camera
            modelBuilder.Entity<Camera>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // Fingerprint
            modelBuilder.Entity<Fingerprint>()
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
        public DbSet<BodyFormFactor>? BodyFormFactors { get; set; }
        public DbSet<BodyIpCertificate> BodyIpCertificates { get; set; }
        public DbSet<BackMaterial> BackMaterials { get; set; }
        public DbSet<FrameMaterial> FrameMaterials { get; set; }
        public DbSet<OS> Oses { get; set; }
        public DbSet<OSVersion> OSVersions { get; set; }
        public DbSet<Chipset> Chipsets { get; set; }
        public DbSet<CardSlot> CardSlots { get; set; }
        public DbSet<DisplayTechnology> DisplayTechnologies { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Fingerprint> Fingerprints { get; set; }
    }
}
