using Bussinessproducts.Migration;
using Bussinessproducts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bussinessproducts.DataAccessLayer
{
    public class BussinessProductContext: DbContext
    {
        public BussinessProductContext() : base("connectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BussinessProductContext, configuration>());
        }

        public DbSet<Admin> admins { get; set; } //Add modle class  Admin.cs
        public DbSet<Product> products { get; set; } //Add modle class  Product.cs
        public DbSet<Purchase> purchases { get; set; } //Add modle class  Product.cs




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }
    }
}