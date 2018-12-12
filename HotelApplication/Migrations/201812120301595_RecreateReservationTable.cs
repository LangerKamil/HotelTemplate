namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateReservationTable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.ReservationStatus", t => t.RStatus_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.RStatus_Id);
            
            AddColumn("dbo.Genders", "Reservation_Id", c => c.Int());
            AddColumn("dbo.RoomTypes", "Reservation_Id", c => c.Int());
            CreateIndex("dbo.Genders", "Reservation_Id");
            CreateIndex("dbo.RoomTypes", "Reservation_Id");
            AddForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations", "Id");
            AddForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RStatus_Id", "dbo.ReservationStatus");
            DropForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.RoomTypes", new[] { "Reservation_Id" });
            DropIndex("dbo.Reservations", new[] { "RStatus_Id" });
            DropIndex("dbo.Reservations", new[] { "Room_Id" });
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropIndex("dbo.Genders", new[] { "Reservation_Id" });
            DropColumn("dbo.RoomTypes", "Reservation_Id");
            DropColumn("dbo.Genders", "Reservation_Id");
            DropTable("dbo.Reservations");
        }
    }
}
