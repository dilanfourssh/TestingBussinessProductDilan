using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Bussinessproducts.Migration
{
    internal sealed class configuration : DbMigrationsConfiguration<Bussinessproducts.DataAccessLayer.BussinessProductContext>
    {
        public configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Tshirt.Context.tshirtContext";
        }

        protected override void Seed(Bussinessproducts.DataAccessLayer.BussinessProductContext context)
        {

        }
    }
}