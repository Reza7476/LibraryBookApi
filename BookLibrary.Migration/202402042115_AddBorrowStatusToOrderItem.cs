using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Migrations;
[Migration(202402042115)]
public class _202402042115_AddBorrowStatusToOrderItem : Migration
{
    public override void Up()
    {
        Alter.Table("OrderItems")
             .AddColumn("BorrowStatus").AsBoolean();
    }


    public override void Down()
    {
        Delete.Column("BorrowStatus").FromTable("OrderItems");
    }

}
