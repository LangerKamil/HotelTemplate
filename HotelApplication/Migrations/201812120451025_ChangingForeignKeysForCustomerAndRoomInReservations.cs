namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingForeignKeysForCustomerAndRoomInReservations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropIndex("dbo.Reservations", new[] { "Room_Id" });
            RenameColumn(table: "dbo.Reservations", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Reservations", name: "Room_Id", newName: "RoomId");
            AlterColumn("dbo.Reservations", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "RoomId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Reservations", "CustomerId");
            CreateIndex("dbo.Reservations", "RoomId");
            AddForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            AlterColumn("dbo.Reservations", "RoomId", c => c.Byte());
            AlterColumn("dbo.Reservations", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Reservations", name: "RoomId", newName: "Room_Id");
            RenameColumn(table: "dbo.Reservations", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Reservations", "Room_Id");
            CreateIndex("dbo.Reservations", "Customer_Id");
            AddForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
