using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Migrations;

[Migration(202402031401)]
public class _202402031401_ModifyBook : Migration
{
    public override void Up()
    {
        Alter.Table("Books")
            .AddColumn("NumberOfBorrowBook").AsInt32().NotNullable();
            
    }
    public override void Down()
    {
        Delete.Column("NumberOfBorrowBook").FromTable("Books");
    }

}
