using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using KTS.Models;


namespace KTS.data
{
    public class ktsContext : DbContext
    {
        public ktsContext() : base("name=KTS")
        {


            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ktsContext, Migrations.KtsStore.Configuration>());
        }

        public DbSet<ProductType> Ptype { get; set; }

        public DbSet<Products> product { get; set; }

        public DbSet<Contract> contracts { get; set; }

        public DbSet<Employee> Emp { get; set; }

        public DbSet<Brands> PBrands { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Booking> bookings { get; set; }

       
        

    }
}