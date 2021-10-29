using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// Data description
namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Material { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

    }

    /// <summary>
    /// For Migrations
    /// </summary>
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseNpgsql("CONNECTION STRING");
            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
