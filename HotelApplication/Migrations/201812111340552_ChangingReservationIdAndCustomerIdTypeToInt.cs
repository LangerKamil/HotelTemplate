namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingReservationIdAndCustomerIdTypeToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropColumn("dbo.Reservations", "CustomerId");
            RenameColumn(table: "dbo.Reservations", name: "Customer_Id", newName: "CustomerId");
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Reservations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Reservations", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "CustomerId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Reservations", "Id");
            CreateIndex("dbo.Reservations", "CustomerId");
            AddForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Reservations", "CustomerId", c => c.Int());
            AlterColumn("dbo.Reservations", "CustomerId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Reservations", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Reservations", "Id");
            RenameColumn(table: "dbo.Reservations", name: "CustomerId", newName: "Customer_Id");
            AddColumn("dbo.Reservations", "CustomerId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Reservations", "Customer_Id");
            AddForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
