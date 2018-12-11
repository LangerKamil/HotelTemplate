namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateReservationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        CustomerId = c.Byte(nullable: false),
                        RoomId = c.Byte(nullable: false),
                        Customer_Id = c.Int(),
                        RStatus_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.ReservationStatus", t => t.RStatus_Id)
                .Index(t => t.RoomId)
                .Index(t => t.Customer_Id)
                .Index(t => t.RStatus_Id);
            
            CreateTable(
                "dbo.ReservationStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RStatus_Id", "dbo.ReservationStatus");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "RStatus_Id" });
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropTable("dbo.ReservationStatus");
            DropTable("dbo.Reservations");
        }
    }
}
