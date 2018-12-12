namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropReservationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RStatus_Id", "dbo.ReservationStatus");
            DropIndex("dbo.Genders", new[] { "Reservation_Id" });
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropIndex("dbo.Reservations", new[] { "Room_Id" });
            DropIndex("dbo.Reservations", new[] { "RStatus_Id" });
            DropIndex("dbo.RoomTypes", new[] { "Reservation_Id" });
            DropColumn("dbo.Genders", "Reservation_Id");
            DropColumn("dbo.RoomTypes", "Reservation_Id");
            DropTable("dbo.Reservations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        Room_Id = c.Byte(),
                        RStatus_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RoomTypes", "Reservation_Id", c => c.Int());
            AddColumn("dbo.Genders", "Reservation_Id", c => c.Int());
            CreateIndex("dbo.RoomTypes", "Reservation_Id");
            CreateIndex("dbo.Reservations", "RStatus_Id");
            CreateIndex("dbo.Reservations", "Room_Id");
            CreateIndex("dbo.Reservations", "Customer_Id");
            CreateIndex("dbo.Genders", "Reservation_Id");
            AddForeignKey("dbo.Reservations", "RStatus_Id", "dbo.ReservationStatus", "Id");
            AddForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations", "Id");
            AddForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations", "Id");
            AddForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
