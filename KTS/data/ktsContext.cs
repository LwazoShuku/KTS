﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using KTS.Models;
using KTS.Migrations.KtsStore;


namespace KTS.data
{
    public class ktsContext : DbContext
    {
        public ktsContext() : base("name=KTS")
        {


            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ktsContext, Configuration>());
        }

        public DbSet<ProductType> Ptype { get; set; }

        public DbSet<Products> product { get; set; }

        public DbSet<Services> services { get; set; }
      

        public DbSet<Brands> PBrands { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Booking> bookings { get; set; }

       public DbSet<Inventory> InventoryT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(c => new {c.dateT,c.time,c.sessionUser });
        }
    }
}