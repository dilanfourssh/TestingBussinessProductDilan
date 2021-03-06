﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Bussinessproducts.Migration
{
    public partial class User: DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.users",
                c => new
                {
                    userId = c.Int(nullable: false, identity: true),
                    name = c.String(),
                })
                .PrimaryKey(t => t.userId);

        }

        public override void Down()
        {
            DropTable("dbo.users");
        }
    }
}