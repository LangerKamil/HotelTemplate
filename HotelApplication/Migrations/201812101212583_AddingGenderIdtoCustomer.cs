namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGenderIdtoCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Customers", new[] { "Gender_Id" });
            RenameColumn(table: "dbo.Customers", name: "Gender_Id", newName: "GenderId");
            AlterColumn("dbo.Customers", "GenderId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "GenderId");
            AddForeignKey("dbo.Customers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "GenderId", "dbo.Genders");
            DropIndex("dbo.Customers", new[] { "GenderId" });
            AlterColumn("dbo.Customers", "GenderId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "GenderId", newName: "Gender_Id");
            CreateIndex("dbo.Customers", "Gender_Id");
            AddForeignKey("dbo.Customers", "Gender_Id", "dbo.Genders", "Id");
        }
    }
}
