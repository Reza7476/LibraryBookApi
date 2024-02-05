using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Migrations;

[Migration(202402041146)]
public class _202402041146_AddRestOfBookColumn : Migration
{

    public override void Up()
    {

        Alter.Table("Books")
            .AddColumn("RestOfBook").AsInt32().NotNullable().WithDefaultValue(3);


    }
    public override void Down()
    {
        Delete.Column("RestOfBook").FromTable("Books");


    }
}