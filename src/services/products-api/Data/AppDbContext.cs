﻿using Microsoft.EntityFrameworkCore;
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
        }



        // Tables
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Availability>? Availabilities { get; set; }
        public DbSet<Network>? Networks { get; set; }
    }
}
