using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=loftBlogASPCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));
            //optionsBuilder.UseNpgsql("Server=ec2-54-146-84-101.compute-1.amazonaws.com;Port=5432;Database=d3bgr2pkr21tu7;User Id=wsmlghywgyjjkt;Password=9bc748df1b6b411484fdc9cba5bc9470ac5f8af85d01e401f08e542317082324;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;");
            optionsBuilder.UseNpgsql("Server=ec2-54-146-84-101.compute-1.amazonaws.com;Port=5432;Database=d3bgr2pkr21tu7;User Id=wsmlghywgyjjkt;Password=9bc748df1b6b411484fdc9cba5bc9470ac5f8af85d01e401f08e542317082324;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;");
            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
