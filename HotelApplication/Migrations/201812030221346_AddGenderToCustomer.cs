namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderToCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Gender_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "Gender_Id");
            AddForeignKey("dbo.Customers", "Gender_Id", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Customers", new[] { "Gender_Id" });
            DropColumn("dbo.Customers", "Gender_Id");
            DropTable("dbo.Genders");
        }
    }
}
