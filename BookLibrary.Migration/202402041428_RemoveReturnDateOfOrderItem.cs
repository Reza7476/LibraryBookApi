using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Migrations;
[Migration(202402041428)]

public class _202402041428_RemoveReturnDateOfOrderItem : Migration
{

    public override void Up()
    {


        Delete.Column("ReturnDate").FromTable("OrderItems");

    }
    public override void Down()
    {
        Alter.Table("OrderItems")
         .AddColumn("ReturnDate").AsDateTime2().NotNullable();

    }
}