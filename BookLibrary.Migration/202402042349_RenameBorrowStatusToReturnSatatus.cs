using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLibrary.Migrations;
[Migration(202402042349)]
public class _202402042349_RenameBorrowStatusToReturnSatatus : Migration
{

    public override void Up()
    {
        Rename.Column("BorrowStatus").OnTable("OrderItems").To("ReturnStatus");
    }
    public override void Down()
    {
        Rename.Column("ReturnStatus").OnTable("OrderItems").To("BorrowStatus");
    }
}
