namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerIdandRoomIdFromReservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            RenameColumn(table: "dbo.Reservations", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Reservations", name: "RoomId", newName: "Room_Id");
            AlterColumn("dbo.Reservations", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Reservations", "Room_Id", c => c.Byte());
            CreateIndex("dbo.Reservations", "Customer_Id");
            CreateIndex("dbo.Reservations", "Room_Id");
            AddForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "Room_Id" });
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            AlterColumn("dbo.Reservations", "Room_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Reservations", "Customer_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reservations", name: "Room_Id", newName: "RoomId");
            RenameColumn(table: "dbo.Reservations", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.Reservations", "RoomId");
            CreateIndex("dbo.Reservations", "CustomerId");
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
