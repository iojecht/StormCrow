﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StormCrow.Data.Configuration;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public class StormCrowDbContext : DbContext
    {
        public StormCrowDbContext() : base("StormCrow") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        static StormCrowDbContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PalletConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
        }
    }
}
