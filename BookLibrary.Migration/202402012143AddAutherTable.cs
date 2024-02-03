using FluentMigrator;

namespace BookLibrary.Migrations;

[Migration(202402012143)]
public class _202402012143_AddAutherTable : Migration
{
    public override void Up()
    {
        Create.Table("Authers")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString(75).WithDefaultValue("Hischkac").NotNullable();


        Create.Table("Genres")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(75).WithDefaultValue("Hichkas").NotNullable();

        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(75).WithDefaultValue("Hichkas").NotNullable()
            .WithColumn("Category").AsString().WithDefaultValue("Hichi").NotNullable()
            .WithColumn("Count").AsInt32()
            .WithColumn("GenreId").AsInt32().NotNullable()
            .ForeignKey("FK_Books_Genres", "Genres", "Id")
            .WithColumn("AutherId").AsInt32().NotNullable()
            .ForeignKey("FK_Books_Authers","Authers", "Id");

        Create.Table("Users")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(75).WithDefaultValue("hichkas").NotNullable()
            .WithColumn("Email").AsString(100).WithDefaultValue("Taav@gmail.com").NotNullable()
            .WithColumn("Phone").AsString(15).WithDefaultValue("09174367476").NotNullable();
       
        Create.Table("Orders")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("IsOpen").AsBoolean()
            .WithColumn("NumberOfBook").AsInt32()
            .WithColumn("UserId").AsInt32()
            .ForeignKey("FK_Orders_Users", "Users", "Id").NotNullable();

        Create.Table("OrderItems")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("NumberOfBook").AsInt32()
            .WithColumn("BorrowDate").AsDateTime().NotNullable()
            .WithColumn("ReturnDate").AsDateTime().NotNullable()
            .WithColumn("BookId").AsInt32()
            .ForeignKey("FK_OrderItems_Books", "Books", "Id").NotNullable()
            .WithColumn("OrderId").AsInt32()
            .ForeignKey("FK_OrerItems_Orders", "Orders", "Id").NotNullable();


    }

    public override void Down()
    {
        Delete.Table("OrderItems");
        Delete.Table("Orders");
        Delete.Table("Users");
        Delete.Table("Books");
        Delete.Table("Genres");
        Delete.Table("Authers");
    }

}
