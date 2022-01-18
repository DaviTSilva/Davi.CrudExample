using Davi.CrudExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Data
{
    public class MarketDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MarketDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            // construct the DB using the project Tomtec.AuthServerAPI as startup
            options.UseSqlServer(Configuration.GetConnectionString("MarketDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(u => new {
                u.Name,
            }).IsUnique();
        }

        public DbSet<Product> Products { get; set; }

    }
}
