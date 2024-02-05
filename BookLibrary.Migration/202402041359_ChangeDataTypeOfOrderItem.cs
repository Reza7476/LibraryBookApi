using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Migrations;
[Migration(202402041359)]
public class _202402041359_ChangeDataTypeOfOrderItem : Migration
{

    public override void Up()
    {

        Alter.Table("OrderItems")
            .AlterColumn("BorrowDate").AsDateTime2().NotNullable()
            .AlterColumn("ReturnDate").AsDateTime2().NotNullable();
    }
    public override void Down()
    {
        Alter.Table("OrderItems")
             .AlterColumn("BorrowDate").AsDateTime().NotNullable()
             .AlterColumn("ReturnDate").AsDateTime().NotNullable();

    }
}
