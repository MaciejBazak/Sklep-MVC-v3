using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sklep__MVC_v3.Migrations;

namespace Sklep__MVC_v3.Models
{
    public class SklepDbContext : DbContext
    {

        public SklepDbContext() : base("MyConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SklepDbContext, Configuration>());
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}