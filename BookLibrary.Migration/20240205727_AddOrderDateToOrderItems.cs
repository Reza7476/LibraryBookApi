using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Migrations;
[Migration(20240205727)]
public class _20240205727_AddOrderDateToOrderItems : Migration
{

    public override void Up()
    {

        Alter.Table("OrderItems")
            .AddColumn("OrderDate").AsDateTime2().NotNullable();

    }
    public override void Down()
    {
        Delete.Column("OrderDate").FromTable("OrderItems");
    }
}
