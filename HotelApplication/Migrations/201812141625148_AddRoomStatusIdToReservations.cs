namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomStatusIdToReservations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "RoomStatusId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "RoomStatusId");
        }
    }
}
