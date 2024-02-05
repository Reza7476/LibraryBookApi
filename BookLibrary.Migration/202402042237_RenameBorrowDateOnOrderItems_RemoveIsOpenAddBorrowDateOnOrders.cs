using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLibrary.Migrations;
[Migration(202402042237)]
public class _202402042237_RenameBorrowDateOnOrderItems_RemoveIsOpenAddBorrowDateOnOrders : Migration
{
    public override void Up()
    {
        Rename.Column("BorrowDate").OnTable("OrderItems").To("ReturnDate");
        Rename.Column("NumberOfBook").OnTable("Orders").To("NumberOfNotReturnedBook");
        Alter.Table("Orders")
            .AddColumn("OrderDate").AsDateTime2().Nullable();
        Delete.Column("IsOpen").FromTable("Orders");

    }


    public override void Down()
    {
        Rename.Column("ReturnDate").OnTable("OrderItems").To("BorrowDate");
        Rename.Column("NumberOfNotReturnedBook").OnTable("Orders").To("NumberOfBook");
        Alter.Table("Orders").AddColumn("IsOpen").AsBoolean().Nullable();
        Delete.Column("OrderDate").FromTable("Orders");
    }

}
