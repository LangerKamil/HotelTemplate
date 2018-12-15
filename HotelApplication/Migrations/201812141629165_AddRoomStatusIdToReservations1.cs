namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomStatusIdToReservations1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reservations", "RoomStatusId");
            AddForeignKey("dbo.Reservations", "RoomStatusId", "dbo.RoomStatus", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RoomStatusId", "dbo.RoomStatus");
            DropIndex("dbo.Reservations", new[] { "RoomStatusId" });
        }
    }
}
